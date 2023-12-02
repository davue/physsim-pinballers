using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics
{
    public abstract class BarObject<T> : SimulatedShape<T> where T : Shape
    {
        public Vector2 Start { get; }
        public Vector2 End { get; }
        public int Length { get; }

        protected BarObject(PinballGame game, Vector2 start, Vector2 end) : base(game)
        {
            Start = start;
            End = end;

            Length = (int)(End - Start).Length();
        }
    }
}
