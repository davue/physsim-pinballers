using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pinballers.Helpers;

namespace Pinballers.Physics.Shapes
{
    public class Line : Shape, ILine
    {
        public Vector2 Start { get; }
        public Vector2 End { get; }
        public int Radius { get; }

        // Utility getters
        public float Angle { get; }
        public Vector2 Difference => End - Start;
        public int Length { get; }
        public Vector2 Direction => Difference / Length;

        public Line(Vector2 start, Vector2 end, int radius)
        {
            Start = start;
            End = end;
            Radius = radius;

            Angle = Difference.Angle();
            Length = (int)Difference.Length();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
            => (this as ILine).Draw(spriteBatch, gameTime, color);
    }
}
