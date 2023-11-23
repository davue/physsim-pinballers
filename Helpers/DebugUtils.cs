using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Pinballers.Helpers;

public class DebugUtils : DrawableGameComponent
{
    private PinballGame _game;
    
    public DebugUtils(PinballGame game) : base(game)
    {
        this._game = game;
    }

    public override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }

    public void DrawFadingPoint(Vector2 pos, int radius)
    {
        _game.Components.Add(new FadingPoint(_game, pos, radius, 300));
    }
}