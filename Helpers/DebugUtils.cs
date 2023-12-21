using Microsoft.Xna.Framework;

namespace Pinballers.Helpers;

public class DebugUtils : DrawableGameComponent
{
    private readonly PinballGame _game;

    public DebugUtils(PinballGame game) : base(game)
        => _game = game;

    public void AddFadingPoint(Vector2 pos, int radius)
        => _game.Components.Add(new FadingPoint(_game, pos, radius, 300));

    public void AddFadingVector(Vector2 origin, Vector2 direction, float scale)
        => _game.Components.Add(new FadingVector(_game, origin, direction, scale, 300));
}