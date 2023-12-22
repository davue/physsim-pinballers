using Microsoft.Xna.Framework;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers.Participants;

public class Bumper : BumperObject<Circle>
{
    public override Color ObjectColor => _currentColor;
    public override ObjectType Type => ObjectType.Static;
    public override Circle Shape { get; }

    private bool _scoreIncremented = false;
    private Color _currentColor = Color.CornflowerBlue;

    private readonly Color _restingColor = Color.CornflowerBlue;

    public Bumper(PinballGame game, Vector2 center, float bumpForce) : base(game, center, bumpForce)
        => Shape = new Circle(center, 15);

    public override void Update(GameTime gameTime)
    {
        var delta = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - Start;
        if (delta <= 200)
        {
            var frac = delta / 200f;
            _currentColor = Color.Lerp(_restingColor, Color.Black, 1f - frac);

            // Only increment the score once
            if (!_scoreIncremented)
            {
                Game.IncrementScore(1);
                _scoreIncremented = true;
            }
        }
        else
        {
            // reset the flag so the score is incremented again
            _scoreIncremented = false;
        }

        base.Update(gameTime);
    }
}