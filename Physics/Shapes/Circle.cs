using System;
using Microsoft.Xna.Framework;

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
            case Capsule:
                var capsule = (Capsule)second;
                var closestPoint = capsule.GetClosestPointTo(Center);
                var distanceVector = Center - closestPoint;
                var distance = distanceVector.Length() - capsule.Radius;
                if (distance < Radius)
                {
                    distanceVector.Normalize();
                    return new Collision(distanceVector, closestPoint + distanceVector * capsule.Radius, distance);
                }
                break;
        }

        return null;
    }

    public override double GetMass()
    {
        return Math.PI * Radius * Radius;
    }
}