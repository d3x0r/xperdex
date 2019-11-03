#region Using statements
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.IO;
#endregion

namespace TestsForFun
{
    public class QuadTree
    {
        #region Properties
        // Must be power of two values. ALL Quads in the tree
        // will be set to this size.
        public const int MinimumLeafSize = 64 * 64;
        #endregion

        #region Fields
        Terrain Terrain;        // Terrain this quad-tree belongs to

        BoundingBox TreeBoundingBox;    // Holds bounding box used for culling

        // This holds the references to the 4 child nodes.
        // These remain null if this quadtree is a leaf node.
        QuadTree TopLeft;
        QuadTree TopRight;
        QuadTree BottomLeft;
        QuadTree BottomRight;
        List<QuadTree> TreeList;

        bool Leaf = false;

        Vector2 FirstCorner = Vector2.Zero;
        Vector2 LastCorner = Vector2.Zero;
        int QuadSize = 0;

        IndexBuffer QuadIndexBuffer;

        int Width;
        int Height;
        int OffsetX;
        int OffsetY;

        // ==========================================================
        // Used for debug only to show how many leaves are drawn
        public int LeavesDrawn
        {
            get { return leavesDrawn; }
            set { leavesDrawn = 0; }
        }
        static int leavesDrawn = 0;
        // ==========================================================

        public bool BoundingBoxHit
        {
            get { return boundingBoxHit; }
            set { boundingBoxHit = value; }
        }
        static bool boundingBoxHit = false;

        #region BoundingBoxMesh DEBUG
        public VertexPositionColor[] boundingBoxMesh
        {
            get { return BoundingBoxMesh; }
        }
        VertexPositionColor[] BoundingBoxMesh;

        #endregion

        BasicEffect lineEffect;
        VertexDeclaration lineVertexDeclaration;

        bool InView = false;

        // Holds heights that determine this tree's bounding box
        float MinHeight = 1000000;
        float MaxHeight = 0;

        int RootWidth;
        #endregion

        #region Initialization
        /// <summary>
        /// Use this constructor only when creating the root node for the entire map
        /// </summary>
        /// <param name="Device">Graphics device</param>
        /// <param name="VerticesList">Full list of vertices for the map</param>
        /// <param name="HeightData">HeightData for the entire map</param>
        /// <param name="effect">Effect for drawing terrain</param>
        /// <param name="TerrainTexture">Texture for the terrain</param>
        public QuadTree(Terrain SourceTerrain, int VerticesLength)
        {
            this.Terrain = SourceTerrain;

            lineEffect = new BasicEffect(Terrain.Device, null);
            lineEffect.VertexColorEnabled = true;

            lineVertexDeclaration = new VertexDeclaration(Terrain.Device,
                                                    VertexPositionColor.VertexElements);

            // This truncation requires all heightmap images to be
            // a power of two in height and width
            Width = (int)Math.Sqrt(VerticesLength);
            Height = Width;
            RootWidth = Width;

            // Vertices are only used for setting up the dimensions of
            // the bounding box. The vertices used in rendering are
            // located in the terrain class.
            SetUpBoundingBoxes();                       
            
            // If this tree is the smallest allowable size, set it as a leaf
            // so that it will not continue branching smaller.
            if (VerticesLength <= MinimumLeafSize)
            {
                Leaf = true;

                CreateBoundingBoxMesh();
            }

            if (Leaf)
                SetUpTerrainIndices();
            else
                BranchOffRoot();
        }

        // Use this when creating child trees/branches
        public QuadTree(ref Terrain SourceTerrain, int VerticesLength,
                        int OffsetX, int OffsetY, int RootWidth)
        {
            this.Terrain = SourceTerrain;

            lineEffect = new BasicEffect(Terrain.Device, null);
            lineEffect.VertexColorEnabled = true;

            lineVertexDeclaration = new VertexDeclaration(Terrain.Device,
                                                          VertexPositionColor.VertexElements);

            this.OffsetX = OffsetX;
            this.OffsetY = OffsetY;

            // This truncation requires all heightmap images to be
            // a power of two in height and width
            Width = ((int)Math.Sqrt(VerticesLength) / 2) + 1;
            Height = Width;
            this.RootWidth = RootWidth;

            SetUpBoundingBoxes();                        

            // If this tree is the smallest allowable size, set it as a leaf
            // so that it will not continue branching smaller.
            if ((Width - 1) * (Height - 1) <= MinimumLeafSize)
            {
                Leaf = true;

                CreateBoundingBoxMesh();
            }

            if (Leaf)
                SetUpTerrainIndices();
            else
                BranchOff();            
        }

        private void SetUpBoundingBoxes()
        {            
            FirstCorner = new Vector2(OffsetX, OffsetY);
            LastCorner = new Vector2(Width - 1 + OffsetX, Height - 1 + OffsetY);
            QuadSize = Width * Height;

            // Determine heights for use with the bounding box
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    if (Terrain.HeightData[x + OffsetX, y + OffsetY] < MinHeight)
                        MinHeight = Terrain.HeightData[x + OffsetX, y + OffsetY] - .1f;
                    else if (Terrain.HeightData[x + OffsetX, y + OffsetY] > MaxHeight)
                        MaxHeight = Terrain.HeightData[x + OffsetX, y + OffsetY];
                }

            TreeBoundingBox = new BoundingBox(new Vector3(FirstCorner.X, FirstCorner.Y, MinHeight), new Vector3(LastCorner.X, LastCorner.Y, MaxHeight));
        }

        private void SetUpTerrainIndices()
        {
            int[] Indices = new int[(Width - 1) * (Height - 1) * 6];

            for (int x = 0; x < Width - 1; x++)
                for (int y = 0; y < Width - 1; y++)
                {
                    Indices[(x + y * (Width - 1)) * 6] = (x + OffsetX + 1) + (y + OffsetY + 1) * RootWidth;
                    Indices[(x + y * (Width - 1)) * 6 + 1] = (x + OffsetX + 1) + (y + OffsetY) * RootWidth;
                    Indices[(x + y * (Width - 1)) * 6 + 2] = x + OffsetX + (y + OffsetY) * RootWidth;

                    Indices[(x + y * (Width - 1)) * 6 + 3] = (x + OffsetX + 1) + (y + OffsetY + 1) * RootWidth;
                    Indices[(x + y * (Width - 1)) * 6 + 4] = x + OffsetX + (y + OffsetY) * RootWidth;
                    Indices[(x + y * (Width - 1)) * 6 + 5] = x + OffsetX + (y + OffsetY + 1) * RootWidth;
                }

            QuadIndexBuffer = new IndexBuffer(Terrain.Device, typeof(int), (Width - 1) * (Height - 1) * 6, BufferUsage.WriteOnly );
            QuadIndexBuffer.SetData(Indices);
        }

        private void CreateBoundingBoxMesh()
        {
            List<Vector3> boxList = new List<Vector3>();

            BoundingBoxMesh = new VertexPositionColor[36];
            for (int i = 0; i < 36; i++)
                BoundingBoxMesh[i].Color = Color.Magenta;

            foreach (Vector3 thisVector in TreeBoundingBox.GetCorners())
            {
                boxList.Add(thisVector);
            }

            // Front
            BoundingBoxMesh[0].Position = boxList[0];
            BoundingBoxMesh[1].Position = boxList[1];
            BoundingBoxMesh[2].Position = boxList[2];

            BoundingBoxMesh[3].Position = boxList[2];
            BoundingBoxMesh[4].Position = boxList[3];
            BoundingBoxMesh[5].Position = boxList[0];

            // Top
            BoundingBoxMesh[6].Position = boxList[0];
            BoundingBoxMesh[7].Position = boxList[5];
            BoundingBoxMesh[8].Position = boxList[1];

            BoundingBoxMesh[9].Position = boxList[0];
            BoundingBoxMesh[10].Position = boxList[4];
            BoundingBoxMesh[11].Position = boxList[5];

            // Left
            BoundingBoxMesh[12].Position = boxList[0];
            BoundingBoxMesh[13].Position = boxList[3];
            BoundingBoxMesh[14].Position = boxList[7];

            BoundingBoxMesh[15].Position = boxList[7];
            BoundingBoxMesh[16].Position = boxList[4];
            BoundingBoxMesh[17].Position = boxList[0];

            // Right
            BoundingBoxMesh[18].Position = boxList[1];
            BoundingBoxMesh[19].Position = boxList[5];
            BoundingBoxMesh[20].Position = boxList[6];

            BoundingBoxMesh[21].Position = boxList[6];
            BoundingBoxMesh[22].Position = boxList[3];
            BoundingBoxMesh[23].Position = boxList[1];

            // Bottom
            BoundingBoxMesh[24].Position = boxList[3];
            BoundingBoxMesh[25].Position = boxList[7];
            BoundingBoxMesh[26].Position = boxList[6];

            BoundingBoxMesh[27].Position = boxList[6];
            BoundingBoxMesh[28].Position = boxList[2];
            BoundingBoxMesh[29].Position = boxList[3];

            // Back
            BoundingBoxMesh[30].Position = boxList[7];
            BoundingBoxMesh[31].Position = boxList[4];
            BoundingBoxMesh[32].Position = boxList[6];

            BoundingBoxMesh[33].Position = boxList[6];
            BoundingBoxMesh[34].Position = boxList[4];
            BoundingBoxMesh[35].Position = boxList[5];
        }
        #endregion

        #region Methods

        // Only called from the main root node
        private void BranchOffRoot()
        {
            TopLeft = new QuadTree(ref Terrain, QuadSize, 0, 0, RootWidth);
            BottomLeft = new QuadTree(ref Terrain, QuadSize, 0, Height / 2 - 1, RootWidth);
            TopRight = new QuadTree(ref Terrain, QuadSize, Width / 2 - 1, 0, RootWidth);
            BottomRight = new QuadTree(ref Terrain, QuadSize, Width / 2 - 1, Height / 2 - 1, RootWidth);

            TreeList = new List<QuadTree>();
            TreeList.Add(TopLeft);
            TreeList.Add(TopRight);
            TreeList.Add(BottomLeft);
            TreeList.Add(BottomRight);
        }

        // This is called to branch off of child nodes
        private void BranchOff()
        {
            TopLeft = new QuadTree(ref Terrain, QuadSize, 0 + OffsetX, 0 + OffsetY, RootWidth);
            BottomLeft = new QuadTree(ref Terrain, QuadSize, 0 + OffsetX, (Height - 1) / 2 - 1 + (OffsetY + 1), RootWidth);
            TopRight = new QuadTree(ref Terrain, QuadSize, (Width - 1) / 2 - 1 + (OffsetX + 1), 0 + OffsetY, RootWidth);
            BottomRight = new QuadTree(ref Terrain, QuadSize, (Width - 1) / 2 - 1 + (OffsetX + 1), (Height - 1) / 2 - 1 + (OffsetY + 1), RootWidth);

            TreeList = new List<QuadTree>();
            TreeList.Add(TopLeft);
            TreeList.Add(TopRight);
            TreeList.Add(BottomLeft);
            TreeList.Add(BottomRight);
        }

        public void Draw(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, BoundingFrustum bFrustum,
                         Light SceneLight, Vector3 CameraForward)
        {
            // View is kept track of for later when vegetation is drawn.
            // This keeps the program from having to calculate the frustum intersections
            // again for each node.
            InView = false;

            if (bFrustum.Intersects(TreeBoundingBox))
            {
                InView = true;

                // Only draw leaves on the tree, never the main tree branches themselves.
                if (Leaf)
                {
                    Terrain.effect.CurrentTechnique = Terrain.effect.Techniques["MultiTexturedNormaled"];
                    Terrain.effect.Parameters["GrassTexture"].SetValue(Terrain.TerrainTextures[0]);
                    Terrain.effect.Parameters["SandTexture"].SetValue(Terrain.TerrainTextures[1]);
                    Terrain.effect.Parameters["RockTexture"].SetValue(Terrain.TerrainTextures[2]);
                    Terrain.effect.Parameters["GrassNormal"].SetValue(Terrain.TerrainTextureNormals[0]);
                    Terrain.effect.Parameters["SandNormal"].SetValue(Terrain.TerrainTextureNormals[1]);
                    Terrain.effect.Parameters["RockNormal"].SetValue(Terrain.TerrainTextureNormals[2]);

                    Matrix WorldMatrix = Matrix.Identity;
                    Terrain.effect.Parameters["xWorld"].SetValue(WorldMatrix);
                    Terrain.effect.Parameters["xView"].SetValue(ViewMatrix);
                    Terrain.effect.Parameters["xProjection"].SetValue(ProjectionMatrix);

                    Terrain.effect.Parameters["LightDirection"].SetValue(SceneLight.Direction);
                    Terrain.effect.Parameters["AmbientColor"].SetValue(SceneLight.AmbientColor);
                    Terrain.effect.Parameters["AmbientPower"].SetValue(SceneLight.AmbientPower);
                    Terrain.effect.Parameters["SpecularColor"].SetValue(SceneLight.SpecularColor);
                    Terrain.effect.Parameters["SpecularPower"].SetValue(SceneLight.SpecularPower);
                    Terrain.effect.Parameters["DiffuseColor"].SetValue(SceneLight.DiffuseColor);
                    Terrain.effect.Parameters["CameraForward"].SetValue(CameraForward);

                    Terrain.Device.Indices = QuadIndexBuffer;

                    Terrain.effect.Begin();
                    foreach (EffectPass pass in Terrain.effect.CurrentTechnique.Passes)
                    {
                        pass.Begin();

                        Terrain.Device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, Width * Height, 0, (Width - 1) * (Height - 1) * 2);

                        pass.End();
                    }
                    Terrain.effect.End();

                    leavesDrawn++;
                }

                // If there are branches on this node, move down through them recursively
                if (TreeList != null)
                {
                    foreach (QuadTree thisTree in TreeList)
                    {
                        thisTree.Draw(gameTime, ref ViewMatrix, ref ProjectionMatrix, bFrustum, SceneLight, CameraForward);
                    }
                }
            }
        }

        public void DrawBoundingBox(ref Matrix ViewMatrix, ref Matrix ProjectionMatrix)
        {
            if (InView)
            {
                // If this node is a leaf, draw the vegetation
                if (Leaf)
                {
                    lineEffect.View = ViewMatrix;
                    lineEffect.Projection = ProjectionMatrix;

                    lineEffect.Begin();
                    lineEffect.CurrentTechnique.Passes[0].Begin();

                    // Draw the triangle.
                    Terrain.Device.VertexDeclaration = lineVertexDeclaration;

                    Terrain.Device.DrawUserPrimitives(PrimitiveType.TriangleList,
                                                      BoundingBoxMesh, 0, 12);

                    lineEffect.CurrentTechnique.Passes[0].End();
                    lineEffect.End();
                }
                else if (TreeList != null)
                {
                    foreach (QuadTree thisTree in TreeList)
                    {
                        thisTree.DrawBoundingBox(ref ViewMatrix, ref ProjectionMatrix);
                    }
                }
            }
        }

        #endregion
    }
}
