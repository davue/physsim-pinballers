using Pinballers.Physics.Shapes;
using System.Linq;

namespace Pinballers.Physics
{
    public class Boundery : SimulatedObject
    {
        private readonly Bounds _bounds;

        public Boundery(PinballGame game) : base(game)
        {
            _bounds = new Bounds(game.Components.OfType<Wall>().Select(w => w.Shape).OfType<Line>());

            InitPhysics(_bounds, ObjectType.Static);
        }
    }
}
