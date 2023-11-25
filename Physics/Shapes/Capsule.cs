using System;
using Microsoft.Xna.Framework;

namespace Pinballers.Physics.Shapes;

public class Capsule : Shape
{
    public Vector2 Start { get; }
    public Vector2 End { get; }
    public float Length { get; }
    public Vector2 Direction { get; }
    public int Radius { get; }

    public Capsule(Vector2 start, Vector2 end, int radius)
    {
        Start = start;
        End = end;

        var diff = end - start;
        Length = diff.Length();

        Direction = diff / Length;
        Radius = radius;
    }

    public Vector2 GetClosestPointTo(Vector2 p)
    {
        float t = Vector2.Dot(p - Start, Direction) / Vector2.Dot(Direction, Direction);
        t = Math.Clamp(t, 0, 1);

        return Start + t * Direction * Length;
    }

    public override double GetMass()
        => Math.PI * Radius * Radius + Radius * Length;
}