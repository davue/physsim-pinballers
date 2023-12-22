using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;
using System.Linq;

namespace Pinballers.Physics
{
    public class Boundary : SimulatedShape<Bounds>
    {
        public override Bounds Shape { get; }
        public override Color ObjectColor => Color.Transparent;
        public override ObjectType Type => ObjectType.Static;

        public Boundary(PinballGame game) : base(game)
        {
            // Grab the lines of all walls
            Shape = new Bounds(game.SimulatedObjects.OfType<Wall>().Select(w => w.Shape).OfType<Line>());
        }
    }
}
