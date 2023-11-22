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
    
    public override Vector2? GetCollisionNormal(Shape second)
    {
        switch (second)
        {
            case Circle:
                throw new System.NotImplementedException();
            case Capsule:
                var capsule = (Capsule)second;
                var closestPoint = capsule.GetClosestPointTo(Center);
                var distance = Center - closestPoint;
                if (distance.Length() < Radius + capsule.Radius)
                {
                    distance.Normalize();
                    return distance;
                }
                break;
        }

        return null;
    }

    public override Vector2 GetClosestPointOnSurface(Shape second)
    {
        switch (second)
        {
            case Circle:
                throw new System.NotImplementedException();
            case Capsule:
                var capsule = (Capsule)second;
                var closestPoint = capsule.GetClosestPointTo(Center);
                var distance = (Center - closestPoint);
                distance.Normalize();
                return closestPoint + distance * capsule.Radius;
            default:
                throw new System.NotImplementedException();
        }
    }

    public override double GetMass()
    {
        return Math.PI*Radius*Radius;
    }
}