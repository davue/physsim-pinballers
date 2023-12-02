using Pinballers.Physics.Shapes;
using System.Linq;

namespace Pinballers.Physics
{
    public class Boundary : SimulatedObject
    {
        private readonly Bounds _bounds;

        public Boundary(PinballGame game) : base(game)
        {
            // Grab the lines of all walls
            _bounds = new Bounds(game.Components.OfType<Wall>().Select(w => w.Shape).OfType<Line>());

            InitPhysics(_bounds, ObjectType.Static);
        }
    }
}
