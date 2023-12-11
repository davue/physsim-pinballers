using Pinballers.Physics.Shapes;

namespace Pinballers.Physics
{
    public abstract class SimulatedShape<T> : SimulatedObject where T : Shape
    {
        protected sealed override Shape ObjectShape => Shape;
        public abstract T Shape { get; }

        protected SimulatedShape(PinballGame game) : base(game) { }
    }
}
