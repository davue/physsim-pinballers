using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pinballers.Helpers;
using System;

namespace Pinballers.Physics.Shapes
{
    public interface ILine
    {
        Vector2 Start { get; }
        Vector2 End { get; }
        public int Radius { get; }

        public float Angle { get; }
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

        public static void Draw(this ILine line, SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            spriteBatch.DrawCentered(TextureHelper.Circle, line.Start, line.Radius, color);

            spriteBatch.DrawRotating(TextureHelper.Point, line.Start, line.Length, line.Radius, line.Angle, color);

            spriteBatch.DrawCentered(TextureHelper.Circle, line.End, line.Radius, color);
        }
    }
}