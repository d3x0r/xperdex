using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TestsForFun
{
    public class Timer : Component
    {
        #region Properties
        #endregion

        #region Fields
        TimeSpan Duration;
        TimeSpan TimeElapsed;
        #endregion

        #region Initialization
        public Timer()
        {

        }

        public Timer(int Milliseconds)
        {
            Duration = new TimeSpan(0, 0, 0, 0, Milliseconds);
        }

        public Timer(TimeSpan Duration)
        {
            this.Duration = Duration;
        }
        #endregion

        #region Methods
        public override void Update( GameTime gameTime )
        {
            TimeElapsed += gameTime.ElapsedGameTime;
        }

        public float Elapsed
        {
            get { return (float)( Duration.TotalMilliseconds - TimeElapsed.TotalMilliseconds ); }
        }

        public bool ReachedDuration
        {
            get
            {
                if (Duration < TimeElapsed)
                    return true;
                else
                    return false;
            }
        }

        public float Cycles
        {
            get { return (float)(TimeElapsed.TotalMilliseconds / Duration.TotalMilliseconds); }
        }

        public void Start()
        {
            TimeElapsed = TimeSpan.Zero;
        }
        #endregion
    }
}
