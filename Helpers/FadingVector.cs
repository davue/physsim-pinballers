using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pinballers.Helpers;

public class FadingVector : DrawableGameComponent
{
    private const int LineWidth = 2;

    private PinballGame _game;
    private readonly Vector2 _origin;
    private readonly Vector2 _direction;
    private readonly float _scale;
    private Texture2D _lineTexture;
    private readonly Rectangle _destRect;
    private readonly float _angle;

    private readonly long _start;
    private readonly int _duration;
    private long _end;

    public FadingVector(PinballGame game, Vector2 origin, Vector2 direction, float scale, int duration) : base(game)
    {
        _game = game;
        _origin = origin;
        _direction = direction;
        _scale = scale;

        _duration = duration;
        _start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        _end = _start + duration;

        _lineTexture = new Texture2D(game.GraphicsDevice, 1, 1);
        _lineTexture.SetData(new[] { Color.White });

        _destRect = new Rectangle((int)origin.X, (int)origin.Y - LineWidth / 2, (int)(direction.Length() * scale),
            LineWidth);
        _angle = (float)Math.Atan(_direction.Y / _direction.X);
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