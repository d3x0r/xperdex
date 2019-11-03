#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace TestsForFun
{
    public struct VertexTerrain
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector4 TerrainColorWeight;

        public static int SizeInBytes = (3 + 3 + 4) * 4;
        public static VertexElement[] VertexElements = new VertexElement[]
        {
            new VertexElement( 0, 0, VertexElementFormat.Vector3, VertexElementMethod.Default, VertexElementUsage.Position, 0 ),
            new VertexElement( 0, sizeof(float) * 3, VertexElementFormat.Vector3, VertexElementMethod.Default, VertexElementUsage.Normal, 0 ),
            new VertexElement( 0, sizeof(float) * 6, VertexElementFormat.Vector4, VertexElementMethod.Default, VertexElementUsage.Color, 0 ),
        };
    }

    public class Terrain : Component
    {
        #region Properties
        #endregion

        #region Fields

        public GraphicsDevice Device
        {
            get { return device; }
            set { device = value; }
        }
        GraphicsDevice device;

        public ContentManager Content
        {
            get { return content; }
            set { content = value; }
        }
        ContentManager content;

        BoundingFrustum CameraFrustum;        

        public int MapWidth;
        public int MapHeight;
        float ElevationStrength;

        /// <summary>
        /// Holds the height (Z coordinate) of each [x, y] coordinate
        /// </summary>
        public float[,] HeightData;

        Color[,] TerrainTypeData;

        /// <summary>
        /// Holds all the vertices for our terrain
        /// </summary>
        VertexBuffer TerrainVertexBuffer;

        /// <summary>
        /// Holds the normal vectors for each vertex in the terrain
        /// </summary>
        Vector3[] TerrainNormals;

        Texture2D HeightMap;
        Texture2D TerrainMap;

        public Texture2D[] TerrainTextures;
        public Texture2D[] TerrainTextureNormals;

        public Effect effect;

        public QuadTree rootQuadTree
        {
            get { return RootQuadTree; }
        }
        QuadTree RootQuadTree;

        // Debug settings
        bool DrawTerrain = true;
        bool DrawBoundingBox = false;
        #endregion

        #region Initialization
        public Terrain(GraphicsDevice inDevice, ContentManager inContentMgr)
        {
            Device = inDevice;
            Content = inContentMgr;

            effect = Content.Load<Effect>("./Effects/Terrain");
        }

        /// <summary>
        /// Initialize main terrain settings.
        /// </summary>
        /// <param name="HeightImagePath">File path for heightmap image, image must be a power of 2 in height and width</param>
        /// <param name="TerrainTexturePath">File path for terrain texture image, image must be a power of 
        /// 2 in height and width. Texture image defines where multi-texture splatting occurs. You can use
        /// this to draw out paths or sections in the terrain.</param>
        /// <param name="SmoothingPasses">Smoothes out the terrain using averages of height. The number of
        /// smoothing passes you choose to make is up to you. If you have sharp
        /// elevations on your map, you have the elevation strength turned up
        /// then you may want a higher value. If your terrain is already smooth
        /// or has very small elevation strength you may not need any passes.
        /// Default value is 5. Use value of 0 to skip smoothing.</param>
        public void Initialize(string HeightImagePath, string TerrainTexturePath, int SmoothingPasses)
        {
            if (SmoothingPasses < 0)
                SmoothingPasses = 5;

            HeightMap = Content.Load<Texture2D>(HeightImagePath);
            TerrainMap = Content.Load<Texture2D>(TerrainTexturePath);

            LoadHeightData();
            LoadTerrainTypeData();
            SmoothTerrain(SmoothingPasses);
            SetUpTerrainVertices();
            

            RootQuadTree = new QuadTree(this, TerrainNormals.Length);
        }

        // <summary>
        /// Initialize main terrain settings. Default smoothing settings will be used.
        /// </summary>
        /// <param name="HeightImagePath">File path for heightmap image, image must be a power of 2 in height and width</param>
        /// <param name="TerrainTexturePath">File path for terrain texture image, image must be a power of 
        /// 2 in height and width. Texture image defines where multi-texture splatting occurs. You can use
        /// this to draw out paths or sections in the terrain.</param>
        public void Initialize(string HeightImagePath, string TerrainTexturePath)
        {
            HeightMap = Content.Load<Texture2D>(HeightImagePath);
            TerrainMap = Content.Load<Texture2D>(TerrainTexturePath);

            LoadHeightData();
            LoadTerrainTypeData();
            SmoothTerrain(5);       // Default of 5 smoothing passes
            SetUpTerrainVertices();


            RootQuadTree = new QuadTree(this, TerrainNormals.Length);
        }

        /// <summary>
        /// Sets up 3 different textures that the terrain can use.
        /// </summary>
        /// <param name="Texture0">Terrain texture #0</param>
        /// <param name="Texture1">Terrain texture #1</param>
        /// <param name="Texture2">Terrain texture #2</param>
        public void InitTerrainTextures(string Texture0, string Texture1, string Texture2)
        {
            TerrainTextures = new Texture2D[3];

            TerrainTextures[0] = Content.Load<Texture2D>(Texture0);
            TerrainTextures[1] = Content.Load<Texture2D>(Texture1);
            TerrainTextures[2] = Content.Load<Texture2D>(Texture2);
        }

        public void InitTerrainNormalsTextures(string Texture0Normal, string Texture1Normal, string Texture2Normal)
        {
            TerrainTextureNormals = new Texture2D[3];

            TerrainTextureNormals[0] = Content.Load<Texture2D>(Texture0Normal);
            TerrainTextureNormals[1] = Content.Load<Texture2D>(Texture1Normal);
            TerrainTextureNormals[2] = Content.Load<Texture2D>(Texture2Normal);
        }

        /// <summary>
        /// Loads in the height data using a height map image.
        /// </summary>
        private void LoadHeightData()
        {
            float minimumHeight = 1000;
            float maximumHeight = 0;

            MapWidth = HeightMap.Width;             // Sets the map width to the same as the heightmap texture.
            MapHeight = HeightMap.Height;           // Same as line above

            // We setup the map for colors so we can use the color to determine elevations of the map
            Color[] heightMapColors = new Color[MapWidth * MapHeight];

            HeightMap.GetData(heightMapColors);     // XNA Built-in feature automatically copies
                                                    // pixel data into the heightmap.

            HeightData = new float[MapWidth, MapHeight];  // Create an array to hold elevations from heightMap

            // If elevation strength was never initialized, use 6 by default.
            if (ElevationStrength < 0.0f)
                ElevationStrength = 6f;

            // Find minimum and maximum values for the heightmap file we read in
            for (int x = 0; x < MapWidth; x++)
                for (int y = 0; y < MapHeight; y++)
                {
                    HeightData[x, y] = heightMapColors[x + y * MapWidth].R;
                    if (HeightData[x, y] < minimumHeight) minimumHeight = HeightData[x, y];
                    if (HeightData[x, y] > maximumHeight) maximumHeight = HeightData[x, y];
                }


            // Set height by color, and then alter height by min and max amounts
            for (int x = 0; x < MapWidth; x++)
                for (int y = 0; y < MapHeight; y++)
                {
                    HeightData[x, y] = (heightMapColors[y + x * MapHeight].R) + (heightMapColors[y + x * MapHeight].G) + (heightMapColors[y + x * MapHeight].B);
                    HeightData[x, y] = (HeightData[x, y] - minimumHeight) / (maximumHeight - minimumHeight) * ElevationStrength;
                }
        }

        private void LoadTerrainTypeData()
        {
            // We setup the map for colors so we can check later for billboard information
            Color[] TerrainTypeColors = new Color[MapWidth * MapHeight];

            TerrainMap.GetData(TerrainTypeColors);        // XNA Built-in feature automatically copies
                                                          // pixel data into the heightmap.

            TerrainTypeData = new Color[MapWidth, MapHeight];

            for (int x = 0; x < MapWidth; x++)
                for (int y = 0; y < MapHeight; y++)
                {
                    TerrainTypeData[x, y] = new Color(TerrainTypeColors[y + x * MapHeight].R,
                                                      TerrainTypeColors[y + x * MapHeight].G,
                                                      TerrainTypeColors[y + x * MapHeight].B);                   
                }
        }

        /// <summary>
        /// This sets up the vertices for all of the triangles.
        /// </summary>
        private void SetUpTerrainVertices()
        {
            VertexTerrain[] TerrainVertices = new VertexTerrain[MapWidth * MapHeight];
            TerrainNormals = new Vector3[MapWidth * MapHeight];

            // Texture the level
            for (int x = 0; x < MapWidth; x++)
                for (int y = 0; y < MapHeight; y++)
                {
                    TerrainVertices[x + y * (MapWidth)].Position = new Vector3(x, y, HeightData[x, y]);
                    TerrainVertices[x + y * MapWidth].TerrainColorWeight = new Vector4(TerrainTypeData[x, y].R * 0.00392f, TerrainTypeData[x, y].G * 0.00392f, TerrainTypeData[x, y].B * 0.00392f, 0);
                }

            // Setup normals for lighting
            for (int x = 1; x < MapWidth - 1; x++)
                for (int y = 1; y < MapHeight - 1; y++)
                {
                    Vector3 normX = new Vector3((TerrainVertices[x - 1 + y * MapWidth].Position.Z - TerrainVertices[x + 1 + y * MapWidth].Position.Z) / 2, 0, 1);
                    Vector3 normY = new Vector3(0, (TerrainVertices[x + (y - 1) * MapWidth].Position.Z - TerrainVertices[x + (y + 1) * MapWidth].Position.Z) / 2, 1);
                    TerrainVertices[x + y * MapWidth].Normal = normX + normY;
                    TerrainVertices[x + y * MapWidth].Normal.Normalize();
                    TerrainNormals[x + y * MapWidth] = TerrainVertices[x + y * MapWidth].Normal;
                }

            TerrainVertexBuffer = new VertexBuffer(Device, VertexTerrain.SizeInBytes * MapWidth * MapHeight, BufferUsage.WriteOnly
				//, ResourceManagementMode.Automatic
				);
            TerrainVertexBuffer.SetData(TerrainVertices);
        }
        #endregion

        #region Methods

        public override void Draw(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, Light SceneLight, Camera CurrentCam)
        {
            CameraFrustum = new BoundingFrustum(ViewMatrix * ProjectionMatrix);

            Device.Vertices[0].SetSource(TerrainVertexBuffer, 0, VertexTerrain.SizeInBytes);
            Device.VertexDeclaration = new VertexDeclaration(Device, VertexTerrain.VertexElements);

            if (DrawTerrain)
                RootQuadTree.Draw(gameTime, ref ViewMatrix, ref ProjectionMatrix, CameraFrustum, SceneLight, CurrentCam.ForwardVector);

            if (DrawBoundingBox)
            {
                Device.RenderState.FillMode = FillMode.WireFrame;
                Device.RenderState.CullMode = CullMode.None;
                Device.RenderState.DepthBufferEnable = false;

                RootQuadTree.DrawBoundingBox(ref ViewMatrix, ref ProjectionMatrix);
            }
        }

        public void ToggleTerrainDraw()
        {
            if (DrawTerrain)
                DrawTerrain = false;
            else
                DrawTerrain = true;
        }

        public void ToggleBoundingBoxDraw()
        {
            if (DrawBoundingBox)
                DrawBoundingBox = false;
            else
                DrawBoundingBox = true;
        }

        public void SetElevationStrength(float Strength)
        {
            ElevationStrength = Strength;
        }

        /// <summary>
        /// Smoothes out the terrain using averages of height. The number of
        /// smoothing passes you choose to make is up to you. If you have sharp
        /// elevations on your map, you have the elevation strength turned up
        /// then you may want a higher value. If your terrain is already smooth
        /// or has very small elevation strength you may not need any passes.        
        /// </summary>
        /// <param name="SmoothingPasses">Number of smoothing passes to make</param>
        public void SmoothTerrain(int Passes)
        {
            float[,] newHeightData;

            while (Passes > 0)
            {
                Passes--;
                newHeightData = new float[MapWidth, MapHeight];

                for (int x = 0; x < MapWidth; x++)
                {
                    for (int y = 0; y < MapHeight; y++)
                    {
                        int adjacentSections = 0;
                        float sectionsTotal = 0.0f;

                        if ((x - 1) > 0)            // Check to left
                        {
                            sectionsTotal += HeightData[x - 1, y];
                            adjacentSections++;

                            if ((y - 1) > 0)        // Check up and to the left
                            {
                                sectionsTotal += HeightData[x - 1, y - 1];
                                adjacentSections++;
                            }

                            if ((y + 1) < MapHeight)        // Check down and to the left
                            {
                                sectionsTotal += HeightData[x - 1, y + 1];
                                adjacentSections++;
                            }
                        }

                        if ((x + 1) < MapWidth)     // Check to right
                        {
                            sectionsTotal += HeightData[x + 1, y];
                            adjacentSections++;

                            if ((y - 1) > 0)        // Check up and to the right
                            {
                                sectionsTotal += HeightData[x + 1, y - 1];
                                adjacentSections++;
                            }

                            if ((y + 1) < MapHeight)        // Check down and to the right
                            {
                                sectionsTotal += HeightData[x + 1, y + 1];
                                adjacentSections++;
                            }
                        }

                        if ((y - 1) > 0)            // Check above
                        {
                            sectionsTotal += HeightData[x, y - 1];
                            adjacentSections++;
                        }

                        if ((y + 1) < MapHeight)    // Check below
                        {
                            sectionsTotal += HeightData[x, y + 1];
                            adjacentSections++;
                        }

                        newHeightData[x, y] = (HeightData[x, y] + (sectionsTotal / adjacentSections)) * 0.5f;
                    }
                }

                // Overwrite the HeightData info with our new smoothed info
                for (int x = 0; x < MapWidth; x++)
                {
                    for (int y = 0; y < MapHeight; y++)
                    {
                        HeightData[x, y] = newHeightData[x, y];
                    }
                }
            }
        }

        public float GetTerrainHeight(float fTerX, float fTerY)
        {
            // we first get the height of 4 points of the quad underneath the point
            // Check to make sure this point is not off the map at all
            int x = (int)fTerX;
            if (x > MapWidth - 2)
                x = MapWidth - 2;
            else if (x < 0)
                x = 0;

            int y = (int)fTerY;
            if (y > MapHeight - 2)
                y = MapHeight - 2;
            else if (y < 0)
                y = 0;

            float fTriY0 = (HeightData[x, y]);
            float fTriY1 = (HeightData[x + 1, y]);
            float fTriY2 = (HeightData[x, y + 1]);
            float fTriY3 = (HeightData[x + 1, y + 1]);

            float fHeight;
            float fSqX = fTerX - x;
            float fSqY = fTerY - y;
            if ((fSqX + fSqY) < 1)
            {
                fHeight = fTriY0;
                fHeight += (fTriY1 - fTriY0) * fSqX;
                fHeight += (fTriY2 - fTriY0) * fSqY;
            }
            else
            {
                fHeight = fTriY3;
                fHeight += (fTriY1 - fTriY3) * (1.0f - fSqY);
                fHeight += (fTriY2 - fTriY3) * (1.0f - fSqX);
            }
            return fHeight;
        }

        public bool IsAboveTerrain(float xPos, float yPos)
        {
            // Keep object from going off the edge of the map
            if (xPos > MapWidth)
                return false;
            else if (xPos < 0)
                return false;

            // Keep object from going off the edge of the map
            if (yPos > MapHeight)
                return false;
            else if (yPos < 0)
                return false;

            return true;
        }

        public Vector3 GetNormal(float fTerX, float fTerY)
        {
            int x = (int)fTerX;
            if (x > MapWidth - 2)
                x = MapWidth - 2;
            else if (x < 0)
                x = 0;

            int y = (int)fTerY;
            if (y > MapHeight - 2)
                y = MapHeight - 2;
            else if (y < 0)
                y = 0;

            return TerrainNormals[x + y * MapWidth];
        }

        #endregion
    }
}
