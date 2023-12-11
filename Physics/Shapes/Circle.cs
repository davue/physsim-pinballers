using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        => spriteBatch.DrawCentered(TextureHelper.Circle, Center, Radius, color);

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
        Line line = bounds.Lines.MinBy(l => Distance(l));

        var closestPoint = line.GetClosestPointTo(Center);
        var distanceVector = Center - closestPoint;
        var distance = distanceVector.Length() - line.Radius;

        Vector2 normal = line.Difference.Perp();
        float sign = -Math.Sign(Vector2.Dot(distanceVector, line.Difference.Perp()));

        if (sign < 0)
        {
            distanceVector.Normalize();
            return new Collision(- distanceVector, closestPoint - distanceVector * line.Radius, distance);
        }

        return null;
    }

    private float Distance(Line line)
    {
        var closestPoint = line.GetClosestPointTo(Center);
        var distanceVector = Center - closestPoint;
        return distanceVector.Length();
    }

    private Collision CollideWithCircle(Circle other) {
        var distanceVector = Center - other.Center;
        var distance = distanceVector.Length();
        if (distance > Radius + other.Radius) return null;
        
        distanceVector.Normalize();
        return new Collision(distanceVector, other.Center + distanceVector * other.Radius, distance);
    }
    
    public override double GetMass()
        => Math.PI * Radius * Radius;
}