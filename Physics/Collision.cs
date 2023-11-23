using Microsoft.Xna.Framework;

namespace Pinballers.Physics;

public class Collision
{
    public readonly Vector2 Normal;
    public readonly Vector2 Point;
    public readonly float Distance;

    public Collision(Vector2 normal, Vector2 point, float distance)
    {
        Normal = normal;
        Point = point;
        Distance = distance;
    }
}