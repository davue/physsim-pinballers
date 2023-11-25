using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pinballers.Helpers;

public class FadingPoint : DrawableGameComponent
{
    private PinballGame _game;
    private readonly long _start;
    private readonly int _duration;
    private long _end;
    private Texture2D _pointTexture;
    private Rectangle _destRect;

    public FadingPoint(PinballGame game, Vector2 position, int radius, int duration) : base(game)
    {
        _game = game;
        _duration = duration;
        _start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        _end = _start + duration;
        _pointTexture = Utils.CreateCircleTexture(_game.GraphicsDevice, 100);
        _destRect = new Rectangle((int)position.X - radius, (int)position.Y - radius, radius * 2, radius * 2);
    }

    public override void Draw(GameTime gameTime)
    {
        var currentMillis = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        if (currentMillis < _end)
        {
            var alpha = (float)(_end - currentMillis) / _duration;
            _game.SpriteBatch.Draw(_pointTexture, _destRect, new Color(0, 0, 255, alpha * 0.8f));
        }
        else
        {
            Dispose();
        }
    }
}