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
    /// <summary>
    /// This is the base class all the 3d objects in a scene are derived from. This
    /// class is not setup as a component because Entities has special functions performed
    /// on them, like collision checking and algorithms. It would be a waste to iterate
    /// through all game components looking only for entities, every loop.
    /// </summary>
    public abstract class BaseEntity : Component
    {
        #region Properties
        #endregion

        #region Fields
        protected GraphicsDevice Device;
        protected ContentManager Content;

        protected TestsMain game;

        protected Physics Physics = Physics.Instance;

        protected Matrix WorldMatrix;

        public Matrix RotationMatrix = Matrix.Identity;

        public bool MarkedForDeletion = false;

        public Vector3 position
        {
            get { return Position; }
        }
        protected Vector3 Position = new Vector3(0, 0, 0);

        public Vector3 rotation
        {
            get { return Rotation; }
        }
        protected Vector3 Rotation = new Vector3(0, 0, 0);

        public float scale
        {
            get { return Scale; }
        }
        protected float Scale = 1f;

        protected float Opacity = 1f;

        public string Name = "No name assigned";

        public Model model
        {
            get { return Model; }
        }
        protected Model Model;

        public string ModelPath;

        protected Matrix[] BoneTransforms;
        #endregion

        #region Initialization
        public BaseEntity()
        {
        }

        public BaseEntity(GraphicsDevice device, ContentManager content, TestsMain game)
        {
            Device = device;
            Content = content;
            this.game = game;
        }

        public virtual void Initialize(Vector3 position, Vector3 rotation, string ModelPath)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.ModelPath = ModelPath;

            this.Model = Content.Load<Model>(ModelPath);
            this.Name = "No name";

            foreach (ModelMesh mesh in this.Model.Meshes)
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.DirectionalLight0.Enabled = true;
                    effect.DirectionalLight1.Enabled = true;
                    effect.DirectionalLight2.Enabled = true;
                }

            BoneTransforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(BoneTransforms);
        }

        public virtual void Initialize(Vector3 position, Vector3 rotation, string ModelPath, string modelName)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.ModelPath = ModelPath;

            this.Model = Content.Load<Model>(ModelPath);
            this.Name = modelName;

            BoneTransforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(BoneTransforms);

            foreach (ModelMesh mesh in this.Model.Meshes)
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.DirectionalLight0.Enabled = true;
                    effect.DirectionalLight1.Enabled = true;
                    effect.DirectionalLight2.Enabled = true;
                }
        }
        #endregion

        #region Methods
        public void SetPosition(Vector3 position)
        {
            this.Position = position;
        }

        public void SetPosition(float x, float y, float z)
        {
            this.Position = new Vector3(x, y, z);
        }        

        public virtual void SetScale(float scale)
        {
            if (scale < 0)
                scale = 0;

            this.Scale = scale;
        }

        public void SetOpacity(float Opacity)
        {
            this.Opacity = Opacity;
        }

        public override void Draw(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, Light SceneLight, Camera CurrentCam)
        {
            RotationMatrix = Matrix.CreateFromYawPitchRoll(Rotation.X, Rotation.Y, Rotation.Z);

            WorldMatrix = Matrix.CreateScale(Scale)
                        * Matrix.CreateRotationX(MathHelper.PiOver2)
                        * Matrix.CreateFromYawPitchRoll(Rotation.X, Rotation.Y, Rotation.Z)
                        * Matrix.CreateTranslation(Position);

            foreach (ModelMesh mesh in this.Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.DirectionalLight0.Direction = SceneLight.Direction;
                    effect.DirectionalLight1.Direction = Vector3.Transform(SceneLight.Direction, Matrix.CreateRotationY(MathHelper.PiOver2));
                    effect.DirectionalLight2.Direction = -SceneLight.Direction;
                    effect.AmbientLightColor = SceneLight.AmbientColor * SceneLight.AmbientPower * 0;
                    effect.DiffuseColor = SceneLight.DiffuseColor * SceneLight.AmbientPower;
                    effect.SpecularColor = SceneLight.SpecularColor * SceneLight.AmbientPower;
                    effect.SpecularPower = SceneLight.SpecularPower * SceneLight.AmbientPower;
                    effect.EmissiveColor = SceneLight.AmbientColor * SceneLight.AmbientPower;

                    effect.View = ViewMatrix;
                    effect.Projection = ProjectionMatrix;
                    effect.World = this.BoneTransforms[mesh.ParentBone.Index] * WorldMatrix;
                    effect.Alpha = Opacity;
                }
                mesh.Draw();
            }
        }

        public void RotateHorizontal(float amount)
        {
            Rotation.Z += amount;
        }

        public void RotateX(float amount)
        {
            Rotation.X += amount;
        }

        public void RotateY(float amount)
        {
            Rotation.Y += amount;
        }

        public void MoveVertical(float amount)
        {
            Position.Z += amount;
        }

        public void MoveX(float amount)
        {
            Position.X += amount;
        }

        public void MoveY(float amount)
        {
            Position.Y += amount;
        }

        public void ModScale(float amount)
        {
            Scale += amount;

            if (Scale < 0.001f)
                Scale = 0.001f;
        }
        #endregion  
    }
}
