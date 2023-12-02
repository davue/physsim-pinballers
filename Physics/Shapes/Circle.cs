using Microsoft.Xna.Framework;
using Pinballers.Helpers;
using System;
using System.Linq;

namespace Pinballers.Physics.Shapes;

public class Circle : Shape
{
    public Vector2 Center;
    public int Radius;

    public Circle(Vector2 position, int radius)
    {
        Center = position;
        Radius = radius;
    }

    public override Collision GetCollision(Shape second)
    {
        switch (second)
        {
            case Circle:
                throw new NotImplementedException();
            case Capsule capsule:
                return CollideWithLine(capsule);
            case Line line:
                var collision = CollideWithLine(line);
                if (collision == null)
                    return null;

                Vector2 normal = line.Difference.Perp();
                float sign = -Math.Sign(Vector2.Dot(collision.Normal, normal));
                return new Collision(sign * collision.Normal, collision.Point, collision.Distance);
            case Bounds bounds:
                return CollideOutOfBounds(bounds);
        }

        return null;
    }

    private Collision CollideWithLine(ILine line)
    {
        var closestPoint = line.GetClosestPointTo(Center);
        var distanceVector = Center - closestPoint;
        var distance = distanceVector.Length() - line.Radius;
        if (distance < Radius)
        {
            distanceVector.Normalize();
            return new Collision(distanceVector, closestPoint + distanceVector * line.Radius, distance);
        }

        return null;
    }

    private Collision CollideOutOfBounds(Bounds bounds)
    {
        Line closest = bounds.Lines.MinBy(l => Distance(l));

        var closestPoint = closest.GetClosestPointTo(Center);
        var distanceVector = Center - closestPoint;

        Vector2 normal = closest.Difference.Perp();
        Vector2 vec = closestPoint + distanceVector * closest.Radius;
        float dotProd = Vector2.Dot(vec, normal);
        float sign = -Math.Sign(dotProd);

        //if (sign > 0)
        //{
        //    return new Collision(distanceVector, closestPoint,0);
        //}

        return null;
    }

    private float Distance(Line line)
    {
        var closestPoint = line.GetClosestPointTo(Center);
        var distanceVector = Center - closestPoint;
        return distanceVector.Length();
    }

    public override double GetMass()
        => Math.PI * Radius * Radius;
}