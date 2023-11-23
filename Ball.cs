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
        Game.SimulatedObjects.Add(this);
        Restitution = 0.9f;
    }

    public override void Draw(GameTime gameTime)
    {
        Game.SpriteBatch.Draw(_ballTexture,
            new Rectangle((int)Center.X - _radius, (int)Center.Y - _radius, _radius * 2, _radius * 2),
            Color.Red);
    }

    public override void Update(GameTime gameTime)
    {
        // Update gravity
        base.Update(gameTime);

        foreach (var simulatedObject in Game.SimulatedObjects)
        {
            // Skip self-collision
            if (simulatedObject.Equals(this)) continue;

            // Check for collisions
            var collision = GetCollision(simulatedObject);
            if (collision == null) continue;
            Game.DebugUtils.DrawFadingPoint(collision.Point, 5);
        
            // Set velocity to reflection vector
            Velocity -= 2 * Vector2.Dot(Velocity, collision.Normal) * collision.Normal;
            Velocity *= Restitution;
                
            // Clamp position
            Center = collision.Point + collision.Normal * _radius;
            break;
        }
        
        _circleShape.Center = Center;
    }
}