using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics
{
    /// <inheritdoc cref="AnchoredObject{T}"/>
    /// <remarks><c>S is T</c> means <c>IAnchoredObject&lt;S&gt; is IAnchoredObject&lt;T&gt;</c></remarks>
    public interface IAnchoredObject<out T> : ISimulatedShape<T> where T : Shape
    {
        Vector2 Center { get; }
        int Length { get; }
        float CurrentAngularVelocity { get; }
        float Angle { get; }
        Vector2 EndPosition { get; }
        float TouchIdentifier { get; }
    }
}
