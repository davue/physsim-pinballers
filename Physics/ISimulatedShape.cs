using Pinballers.Drawable;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics
{
    /// <summary>
    /// This interface is here to have covariance.
    /// </summary>
    /// <remarks><c>S is T</c> means <c>ISimulatedShape&lt;S&gt; is ISimulatedShape&lt;T&gt;</c></remarks>
    public interface ISimulatedShape<out T> : IDrawableShape<T> where T : Shape
    {
        ObjectType Type { get; }
        Collision GetCollision(ISimulatedShape<Shape> second);
        double Mass { get; }
    }
}
