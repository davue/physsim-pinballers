using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics;

/// <summary>
/// <typeparamref name="T"/> that is affected by <see cref="PinballGame.Gravity"/> and moves according to a <see cref="Velocity"/>
/// </summary>
public abstract class DynamicObject<T> : SimulatedShape<T> where T : Shape
{
    public Vector2 Center;
    public Vector2 Velocity = Vector2.Zero;
    public abstract float Restitution { get; }

    public DynamicObject(PinballGame game, Vector2 center) : base(game)
        => Center = center;

    public override void Update(GameTime gameTime)
    {
        Velocity += Game.Gravity * gameTime.ElapsedGameTime.Milliseconds;
        Center += Velocity * gameTime.ElapsedGameTime.Milliseconds;
    }
}