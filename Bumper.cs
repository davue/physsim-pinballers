using System;
using Microsoft.Xna.Framework;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers;

public class Bumper : BumperObject<Circle>
{
    public Color CurrentColor = Color.CornflowerBlue;
    public override Color ObjectColor => Color.CornflowerBlue;
    public override ObjectType Type => ObjectType.Static;
    public override Circle Shape { get; }
    private bool _scoreIncremented;

    public Bumper(PinballGame game, Vector2 center, float bumpForce) : base(game, center, bumpForce)
    {
        Shape = new Circle(center, 15);
        _scoreIncremented = false;
    }

    public override void Update(GameTime gameTime)
    {
        var delta = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - Start;
        if (delta <= 200)
        {
            var frac = delta / 200f;
            CurrentColor = Color.Lerp(ObjectColor, Color.Black, 1f - frac);

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

    public override void Draw(GameTime gameTime)
        => ObjectShape.Draw(Game.SpriteBatch, gameTime, CurrentColor);
}