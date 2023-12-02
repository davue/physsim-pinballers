using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics;

public abstract class SimulatedObject : DrawableGameComponent
{
    protected new PinballGame Game { get; }
    public abstract Color ObjectColor { get; }
    protected abstract Shape ObjectShape { get; }
    public abstract ObjectType Type { get; }

    protected SimulatedObject(PinballGame game) : base(game)
    {
        Game = game;
        Game.SimulatedObjects.Add(this);
    }

    public sealed override void Draw(GameTime gameTime)
        => ObjectShape.Draw(Game.SpriteBatch, gameTime, ObjectColor);

    public Collision GetCollision(SimulatedObject second)
        => ObjectShape.GetCollision(second.ObjectShape);

    public double Mass => ObjectShape.GetMass();

    protected override void Dispose(bool disposing)
    {
        Game.SimulatedObjects.Remove(this);
        Game.Components.Remove(this);
        base.Dispose(disposing);
    }
}