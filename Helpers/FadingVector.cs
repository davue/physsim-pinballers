using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Pinballers.Helpers;

public class FadingVector : DrawableGameComponent
{
    private const int LineWidth = 2;

    private readonly PinballGame _game;
    private readonly Vector2 _origin;
    private readonly Vector2 _direction;
    private readonly float _scale;
    private readonly Texture2D _lineTexture;
    private readonly float _angle;

    private readonly long _start;
    private readonly int _duration;
    private readonly long _end;

    public FadingVector(PinballGame game, Vector2 origin, Vector2 direction, float scale, int duration) : base(game)
    {
        _game = game;
        _origin = origin;
        _direction = direction;
        _scale = scale;

        _duration = duration;
        _start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        _end = _start + duration;

        _lineTexture = Utils.CreatePointTexture(game.GraphicsDevice);

        _angle = _direction.Angle();
    }

    public override void Draw(GameTime gameTime)
    {
        var currentMillis = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        if (currentMillis < _end)
        {
            var alpha = (float)(_end - currentMillis) / _duration;
            _game.SpriteBatch.DrawRotating(_lineTexture, _origin, (int)(_direction.Length() * _scale), LineWidth / 2, _angle, Color.Lime);
        }
        else
        {
            Dispose();
        }
    }
}