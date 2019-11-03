#region USING STATEMENTS
using System;
using Microsoft.Xna.Framework;
#endregion

namespace TestsForFun
{
    // This class is setup as a singleton class
    public sealed class MathUtils
    {
        #region Properties
        #endregion

        #region Fields
        private Random random = new Random();
        #endregion

        #region Initialization
        static readonly MathUtils instance = new MathUtils();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static MathUtils()
        {
        }

        MathUtils()
        {
        }
        #endregion

        #region Methods
        // Gives access outside of class
        public static MathUtils Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Checks whether an object is in the field of view of another
        /// </summary>
        /// <param name="posFirst">Source object 3d's position</param>
        /// <param name="facingFirst">Source object's facing direction vector</param>
        /// <param name="posSecond">Target object 3d's position</param>
        /// <param name="fov">Field of view angle of source object in radians</param>
        /// <returns>True/false whether or not the second object is in the FOV of the first</returns>
        public bool isSecondInFOVofFirst(Vector3 posFirst, Vector3 facingFirst,
                                         Vector3 posSecond, double fov)
        {
            Vector3 tempVect = posSecond - posFirst;
            tempVect.Normalize();

            return Vector3.Dot(facingFirst, tempVect) >= Math.Cos(fov);
        }

        public float DotFacingFirstToSecond(Vector3 posFirst, Vector3 facingFirst,
                                            Vector3 posSecond)
        {
            Vector3 tempVect = posSecond - posFirst;
            tempVect.Normalize();

            return Vector3.Dot(facingFirst, tempVect);
        }

        public Vector3 VectorFirstToSecond(Vector3 posFirst, Vector3 posSecond)
        {
            return (posSecond - posFirst);
        }

        public bool CheckIfInView(Vector3 posFirst, Vector3 facingFirst, Vector3 posSecond, float viewRange, float viewingAngle)
        {
            // Checks if object is in field of view of the camera
            if (isSecondInFOVofFirst(posFirst, facingFirst, posSecond, MathHelper.ToRadians(viewingAngle)) == true)
            {
                // Checks if object is within the object's viewing range
                if (Math.Sqrt((posSecond.X - posFirst.X) * (posSecond.X - posFirst.X)
                            + (posSecond.Y - posFirst.Y) * (posSecond.Y - posFirst.Y))
                            < (viewRange * 4))
                    return true;
            }

            // If no other entity is spotted by this entity
            return false;
        }

        public float RandomBetween(double min, double max)
        {
            return (float)(min + (float)random.NextDouble() * (max - min));
        }

        public int Random5050
        {
            get
            {
                if (RandomBetween(0, 2) >= 1)
                    return 1;
                else
                    return -1;
            }
        }
        #endregion
    }
}
