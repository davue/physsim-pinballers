using Microsoft.Xna.Framework;
using System;

namespace Pinballers.Physics.Shapes;

public class Capsule : Shape, ILine
{
    public Vector2 Start { get; }
    public Vector2 End { get; set; }
    public int Radius { get; }

    // Utility getters
    public Vector2 Difference => End - Start;
    public int Length { get; }
    public Vector2 Direction => Difference / Length;

    public Capsule(Vector2 start, Vector2 end, int radius)
    {
        Start = start;
        End = end;
        Radius = radius;

        Length = (int)Difference.Length();
    }

    public override double GetMass()
        => Math.PI * Radius * Radius + Radius * Length;
}