using Microsoft.Xna.Framework;
using System;

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
            case Circle circle:
                return CollideWithCircle(circle);
            case Capsule capsule:
                return CollideWithLine(capsule);
            case Line line:
                var collision = CollideWithLine(line);
                if (collision == null)
                    return null;

                Vector2 normal = line.Difference.Perp();
                float sign = -Math.Sign(Vector2.Dot(collision.Normal, normal));
                return new Collision(sign * collision.Normal, collision.Point, collision.Distance);
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

    private Collision CollideWithCircle(Circle other) {
        var distanceVector = Center - other.Center;
        var distance = distanceVector.Length();
        if (distance > Radius + other.Radius) return null;
        
        distanceVector.Normalize();
        return new Collision(distanceVector, other.Center + distanceVector * other.Radius, distance);
    }
    
    public override double GetMass()
    {
        return Math.PI * Radius * Radius;
    }
}