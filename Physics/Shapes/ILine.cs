using Microsoft.Xna.Framework;
using System;

namespace Pinballers.Physics.Shapes
{
    public interface ILine
    {
        Vector2 Start { get; }
        Vector2 End { get; }
        public int Radius { get; }

        Vector2 Difference { get; }
        int Length { get; }
        Vector2 Direction { get; }
    }

    public static class LineExtension
    {
        public static Vector2 GetClosestPointTo(this ILine line, Vector2 p)
        {
            float t = Vector2.Dot(p - line.Start, line.Direction) / line.Length;
            t = Math.Clamp(t, 0, 1);

            return line.Start + t * line.Difference;
        }
    }
}