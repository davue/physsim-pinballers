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
    }

    public override void Draw(GameTime gameTime)
    {
        Game.SpriteBatch.Draw(_ballTexture,
            new Rectangle((int)Center.X - _radius, (int)Center.Y - _radius, _radius * 2, _radius * 2),
            Color.Red);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        foreach (var simulatedObject in Game.SimulatedObjects)
        {
            if (simulatedObject.Equals(this))
                continue;

            // Check for collisions
            var collisionNormal = GetCollisionNormal(simulatedObject);
            if (collisionNormal.HasValue)
            {
                // Set velocity to reflection vector
                Velocity -= 2 * (Velocity * collisionNormal.Value) * collisionNormal.Value;
                
                // Clamp position
                Center = Shape.GetClosestPointOnSurface(simulatedObject.Shape) + collisionNormal.Value * _radius;
            }
        }
        
        _circleShape.Center = Center;
    }
}