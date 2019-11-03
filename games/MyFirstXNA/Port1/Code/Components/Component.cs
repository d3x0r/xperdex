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
    /// Components are a very generic base class that allows
    /// you to simplify drawing and updating of many things.
    /// You can create classes that derive from this base class
    /// and then add them to the ComponentList and they will
    /// automatically draw and update every loop. If you want
    /// to control the time of updating or drawing then you
    /// simply do not add your component to the list, and call
    /// the updating, drawing, or anything else on your own.
    /// Additionally, if you want auto updating but not auto
    /// drawing, or vice-versa, you can set that using the
    /// SetAutoUpdate or SetAutoDraw commands within the component.
    /// At which point you can choose to update or draw manually,
    /// or not at all.
    /// Components are similar to the XNA DrawableGameComponent class. I
    /// chose not to use them because I wanted something more flexible,
    /// and by doing it this way, the beginner programmers can learn more
    /// about creating abstract component classes.
    /// </summary>
    public abstract class Component
    {
        #region Properties
        #endregion

        #region Fields
        public bool Initialized = false;

        public bool autoUpdate
        {
            get { return AutoUpdate; }
        }
        protected bool AutoUpdate = true;

        public bool autoDraw
        {
            get { return AutoDraw; }
        }
        protected bool AutoDraw = true;
        #endregion

        #region Initialization
        public Component()
        {

        }
        #endregion

        #region Methods
        public void Initialize()
        {
            Initialized = true;
        }

        public virtual void Draw(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, Light SceneLight, Camera CurrentCam)
        {
            // Not abstract because not all Components need to be drawn
        }

        public virtual void Update(GameTime gameTime)
        {
            // Not abstract because not all Components need to be updated
        }

        public void SetAutoDraw(bool AutoDraw)
        {
            this.AutoDraw = AutoDraw;
        }

        public void SetAutoUpdate(bool AutoUpdate)
        {
            this.AutoUpdate = AutoUpdate;
        }
        #endregion
    }
}
