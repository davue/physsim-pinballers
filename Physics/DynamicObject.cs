using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics;

public class DynamicObject : SimulatedObject
{
    public Vector2 Center;
    public Vector2 Velocity = Vector2.Zero;
    public double Mass;
    public float Restitution = 1;

    public DynamicObject(PinballGame game, Vector2 center) : base(game)
    {
        Center = center;
    }

    public override void Update(GameTime gameTime)
    {
        Center += Velocity * gameTime.ElapsedGameTime.Milliseconds;
        Velocity += Game.Gravity * gameTime.ElapsedGameTime.Milliseconds;
    }

    public override void InitPhysics(Shape shape, ObjectType objectType)
    {
        base.InitPhysics(shape, objectType);
        Mass = Shape.GetMass();
    }
}