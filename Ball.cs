using Microsoft.Xna.Framework;
using Pinballers.Helpers;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers;

public class Ball : DynamicObject<Circle>
{
    public override Circle Shape { get; }
    public override Color ObjectColor => Color.Red;
    public override ObjectType Type => ObjectType.Dynamic;

    public Ball(PinballGame game, Vector2 startPosition, int radius) : base(game, startPosition)
    {
        Shape = new Circle(startPosition, radius);

        // Initialize Physics
        Restitution = 0.7f;
    }

    public override void Update(GameTime gameTime)
    {
        // Update gravity
        base.Update(gameTime);

        Shape.Center = Center;

        foreach (var simulatedObject in Game.SimulatedObjects)
        {
            // Skip self-collision
            if (simulatedObject.Equals(this)) continue;

            // Check for collisions
            var collision = GetCollision(simulatedObject);
            if (collision == null) continue;

            // Debug drawings
            Game.DebugUtils.AddFadingPoint(collision.Point, 4);
            Game.DebugUtils.AddFadingVector(collision.Point, collision.Normal, 30);

            // Push out ball
            Center = collision.Point + collision.Normal * Shape.Radius;
            Shape.Center = Center;
            
            // Handle collision with anchored objects (like flippers)
            if (simulatedObject is AnchoredObject<Capsule> anchoredObject)
            {
                var originVector = collision.Point - anchoredObject.Center;
                var surfaceVector = originVector.Perp();
                var surfaceVelocity = surfaceVector * anchoredObject.CurrentAngularVelocity;
                var v = Vector2.Dot(Velocity, collision.Normal);
                var vnew = Vector2.Dot(surfaceVelocity, collision.Normal) + Math.Abs(v);

                Velocity += collision.Normal * (vnew - v);
            }
            else if (simulatedObject is BumperObject<Circle> bumperObject)
            {
                Velocity -= 2 * Vector2.Dot(Velocity, collision.Normal) * collision.Normal;
                Velocity += Velocity.Normalized() * bumperObject.BumpForce;
            }
            else
            {
                // Set velocity to reflection vector
                Velocity -= 2 * Vector2.Dot(Velocity, collision.Normal) * collision.Normal;
            }

            // Apply restitution based on collision normal
            // var range = 1 - Restitution;
            // var restitutionVector = new Vector2(1 - range * Math.Abs(Vector2.Dot(collision.Normal, Vector2.UnitX)),
            //     1 - range * Math.Abs(Vector2.Dot(collision.Normal, Vector2.UnitY)));
            //
            // Velocity *= restitutionVector;

            // Add some small normal velocity to fix sticking to slopes
            // TODO: This is just a hacky fix and we should identify the underlying problem
            Velocity += collision.Normal * 0.04f;
            
            // Apply restitution
            Velocity *= Restitution;
        }
    }
}