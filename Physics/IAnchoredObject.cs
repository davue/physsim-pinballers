using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics
{
    /// <summary>
    /// This interface is here to have covariance.
    /// </summary>
    /// <remarks><c>S is T</c> means <c>IAnchoredObject&lt;S&gt; is IAnchoredObject&lt;T&gt;</c></remarks>
    public interface IAnchoredObject<out T> where T : Shape
    {
        Vector2 Center { get; }
        int Length { get; }
        float CurrentAngularVelocity { get; }
        float Angle { get; }
        Vector2 EndPosition { get; }
        float TouchIdentifier { get; }

        T Shape { get; }
    }
}
