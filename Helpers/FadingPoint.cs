using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Pinballers.Helpers;

public class FadingPoint : DrawableGameComponent
{
    private readonly PinballGame _game;
    private readonly long _start;
    private readonly int _duration;
    private readonly long _end;
    private readonly Texture2D _pointTexture;
    private readonly Vector2 _position;
    private readonly int _radius;

    public FadingPoint(PinballGame game, Vector2 position, int radius, int duration) : base(game)
    {
        _game = game;
        _duration = duration;
        _start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        _end = _start + duration;
        _pointTexture = Utils.CreateCircleTexture(_game.GraphicsDevice, 100);
        _position = position;
        _radius = radius;
    }

    public override void Draw(GameTime gameTime)
    {
        var currentMillis = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        if (currentMillis < _end)
        {
            var alpha = (float)(_end - currentMillis) / _duration;
            _game.SpriteBatch.DrawCentered(_pointTexture, _position, _radius, new Color(0, 0, 255, alpha * 0.8f));
        }
        else
        {
            Dispose();
        }
    }
}