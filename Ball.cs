using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers;

public class Ball : DynamicObject
{
    private Circle _circleShape;

    // Ball attributes
    private int _radius;

    // Stuff for drawing
    private Texture2D _ballTexture;

    public Ball(PinballGame game, Vector2 startPosition, int radius) : base(game, startPosition)
    {
        _circleShape = new Circle(startPosition, radius);
        _radius = radius;

        _ballTexture = Utils.CreateCircleTexture(game.GraphicsDevice, 100);

        // Initialize Physics
        base.InitPhysics(_circleShape, ObjectType.Dynamic);
        Restitution = 0.9f;
    }

    public override void Draw(GameTime gameTime)
        => Game.SpriteBatch.DrawCentered(_ballTexture, Center, _radius, Color.Red);

    public override void Update(GameTime gameTime)
    {
        // Update gravity
        base.Update(gameTime);

        _circleShape.Center = Center;

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
            Center = collision.Point + collision.Normal * _radius;
            _circleShape.Center = Center;
            
            // Handle collision with anchored objects (like flippers)
            if (simulatedObject is AnchoredObject anchoredObject)
            {
                var originVector = collision.Point - anchoredObject.Center;
                var surfaceVector = new Vector2(-originVector.Y, originVector.X);
                var surfaceVelocity = surfaceVector * anchoredObject.CurrentAngularVelocity;
                var v = Vector2.Dot(Velocity, collision.Normal);
                var vnew = Vector2.Dot(surfaceVelocity, collision.Normal) + Math.Abs(v);

                Velocity += collision.Normal * (vnew - v);
            }
            else
            {
                // Set velocity to reflection vector
                Velocity -= 2 * Vector2.Dot(Velocity, collision.Normal) * collision.Normal;
            }
            
            // Apply restitution
            Velocity *= Restitution;
        }
    }
}