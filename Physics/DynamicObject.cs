using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics;

public class DynamicObject : SimulatedObject
{
    protected new readonly PinballGame Game;

    public Vector2 Center;
    public Vector2 Velocity = Vector2.Zero;
    public double Mass;
    public float Restitution;

    public DynamicObject(PinballGame game, Vector2 center) : base(game)
    {
        Game = game;
        Center = center;
    }

    public override void Update(GameTime gameTime)
    {
        Center += Velocity * gameTime.ElapsedGameTime.Milliseconds;
        Velocity += Game.Gravity;
    }

    public override void InitPhysics(Shape shape, ObjectType objectType)
    {
        base.InitPhysics(shape, objectType);
        Mass = Shape.GetMass();
    }
}