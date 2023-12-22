using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pinballers.Helpers;
using System;

namespace Pinballers.Physics.Shapes
{
    public class Cross : Shape
    {
        public Vector2 Center { get; }

        // 4 Edges named after direction at 0°. East set from outside, rest computed
        public Vector2 East { get; set; }
        public Vector2 North => Center - Difference.Perp();
        public Vector2 West => Center - Difference;
        public Vector2 South => Center + Difference.Perp();
        public int Radius { get; }

        // Utility getters
        public float Angle { get; set; }
        public Vector2 Difference => East - Center;
        public int Length { get; }
        public int Span { get; }
        public Vector2 Direction => Difference / Length;

        public Cross(Vector2 start, Vector2 end, int radius)
        {
            Center = start;
            East = end;
            Radius = radius;

            Angle = Difference.Angle();
            Length = (int)Difference.Length();
            Span = 2 * Length;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            // 2 Lines from center
            spriteBatch.DrawCenteredRotating(TextureHelper.Point, Center, Span, Radius, Angle, color);
            spriteBatch.DrawCenteredRotating(TextureHelper.Point, Center, Span, Radius, (float)(Angle + Math.PI / 2), color);

            // 4 Rounded edges
            spriteBatch.DrawCentered(TextureHelper.Circle, East, Radius, color);
            spriteBatch.DrawCentered(TextureHelper.Circle, North, Radius, color);
            spriteBatch.DrawCentered(TextureHelper.Circle, West, Radius, color);
            spriteBatch.DrawCentered(TextureHelper.Circle, South, Radius, color);
        }

        // 4 rounded edges + 2 bars - bar overlap
        public override double GetMass()
            => 2 * Math.PI * Radius * Radius + 4 * Radius * Span - 4 * Radius * Radius;
    }
}
