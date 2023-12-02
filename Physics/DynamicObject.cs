using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics;

public abstract class DynamicObject<T> : SimulatedShape<T> where T : Shape
{
    public Vector2 Center;
    public Vector2 Velocity = Vector2.Zero;
    public float Restitution = 1;

    public DynamicObject(PinballGame game, Vector2 center) : base(game)
    {
        Center = center;
    }

    public override void Update(GameTime gameTime)
    {
        Velocity += Game.Gravity * gameTime.ElapsedGameTime.Milliseconds;
        Center += Velocity * gameTime.ElapsedGameTime.Milliseconds;
    }
}