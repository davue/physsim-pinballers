using Microsoft.Xna.Framework;
using System;

namespace Pinballers.Helpers
{
    public static class Vector2Extension
    {
        /// <summary>
        /// Return perpendicular vector (-v.Y, v.X)
        /// </summary>
        public static Vector2 Perp(this Vector2 v) => new(-v.Y, v.X);

        /// <summary>
        /// Compute the angle a vector
        /// </summary>
        /// <remarks>Takes XNA's coordinate system having flipped sign on Y into account</remarks>
        public static float Angle(this Vector2 v) => (float)Math.Atan2(-v.Y, v.X);

        /// <summary>
        /// Return normalized vector without modifying the original
        /// </summary>
        public static Vector2 Normalized(this Vector2 v) => v / v.Length();
    }
}
