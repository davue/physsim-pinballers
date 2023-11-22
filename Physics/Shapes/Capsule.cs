using System;
using Microsoft.Xna.Framework;

namespace Pinballers.Physics.Shapes;

public class Capsule : Shape
{
    private Vector2 _start;
    private Vector2 _end;
    public int Radius;
    public readonly float Length;
    public Vector2 Direction;
    private Vector2 _normal;

    public Capsule(Vector2 start, Vector2 end, int radius)
    {
        _start = start;
        _end = end;
        Radius = radius;

        // Calculate direction vector and length
        Direction = end - start;
        Length = Direction.Length();

        // Copy direction vector and normalize it
        _normal = new Vector2(Direction.X, Direction.Y);
        _normal.Normalize();
    }

    public override bool CheckCollision(Shape second)
    {
        switch (second)
        {
            case Circle:
                throw new System.NotImplementedException();
            case Capsule:
                throw new System.NotImplementedException();
        }

        return false;
    }

    public Vector2 GetClosestPointTo(Vector2 p)
    {
        float t = Vector2.Dot(p - _start, Direction) / Vector2.Dot(Direction, Direction);
        t = Math.Clamp(t, 0, 1);

        return _start + t * Direction;
    }
}