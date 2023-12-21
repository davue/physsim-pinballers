using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics;

public abstract class DrawableObject : DrawableGameComponent
{
    protected new PinballGame Game { get; }
    public abstract Color ObjectColor { get; }
    protected abstract Shape ObjectShape { get; }

    protected DrawableObject(PinballGame game) : base(game)
        => Game = game;

    public override void Draw(GameTime gameTime)
        => ObjectShape.Draw(Game.SpriteBatch, gameTime, ObjectColor);

    protected override void Dispose(bool disposing)
    {
        Game.Components.Remove(this);
        base.Dispose(disposing);
    }
}