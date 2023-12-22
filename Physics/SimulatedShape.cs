using Pinballers.Drawable;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics
{
    public abstract class SimulatedShape<T> : DrawableShape<T>, ISimulatedShape<T> where T : Shape
    {
        public abstract ObjectType Type { get; }

        protected SimulatedShape(PinballGame game) : base(game)
            => Game.SimulatedObjects.Add(this);

        public Collision GetCollision(ISimulatedShape<Shape> second)
            => Shape.GetCollision(second.Shape);

        public double Mass => Shape.GetMass();

        protected override void Dispose(bool disposing)
        {
            Game.SimulatedObjects.Remove(this);
            base.Dispose(disposing);
        }
    }
}
