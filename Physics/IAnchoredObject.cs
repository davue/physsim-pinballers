using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics
{
    public interface IAnchoredObject<out T> where T : Shape
    {
        Vector2 Center { get; }
        int Length { get; }
        float CurrentAngularVelocity { get; }
        float Angle { get; }
        Vector2 EndPosition { get; }

        T Shape { get; }
    }
}
