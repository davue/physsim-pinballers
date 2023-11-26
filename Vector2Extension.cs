using Microsoft.Xna.Framework;

namespace Pinballers
{
    public static class Vector2Extension
    {
        public static Vector2 Perp(this Vector2 v) => new(-v.Y, v.X);
    }
}
