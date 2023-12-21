using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers.Drawable
{
    public abstract class DrawableShape<T> : DrawableObject where T : Shape
    {
        protected sealed override Shape ObjectShape => Shape;
        public abstract T Shape { get; }

        protected DrawableShape(PinballGame game) : base(game) { }
    }
}
