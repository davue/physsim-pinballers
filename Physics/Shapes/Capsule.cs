using Microsoft.Xna.Framework;
using System;

namespace Pinballers.Physics.Shapes;

public class Capsule : Shape
{
    public Vector2 Start { get; }
    public Vector2 End { get; set; }
    public int Radius { get; }

    // Utility getters
    public Vector2 Difference => End - Start;
    public float Length { get; }
    public Vector2 Direction => Difference / Length;

    public Capsule(Vector2 start, Vector2 end, int radius)
    {
        Start = start;
        End = end;
        Radius = radius;

        Length = Difference.Length();
    }

    public Vector2 GetClosestPointTo(Vector2 p)
    {
        float t = Vector2.Dot(p - Start, Direction) / Length;
        t = Math.Clamp(t, 0, 1);

        return Start + t * Difference;
    }

    public override double GetMass()
        => Math.PI * Radius * Radius + Radius * Length;
}