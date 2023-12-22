using Microsoft.Xna.Framework;

namespace Pinballers.Helpers;

public class DebugUtils : DrawableGameComponent
{
    private readonly PinballGame _game;

    public DebugUtils(PinballGame game) : base(game)
        => _game = game;

    public void AddFadingPoint(Vector2 pos, int radius)
        => new FadingPoint(_game, pos, radius, 300);

    public void AddFadingVector(Vector2 origin, Vector2 direction, float scale)
        => new FadingVector(_game, origin, direction, scale, 300);
}