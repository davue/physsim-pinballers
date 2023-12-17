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
    
    public Bumper(PinballGame game, Vector2 center, float bumpForce) : base(game, center, bumpForce)
    {
        Shape = new Circle(center, 15);
    }

    public override void Update(GameTime gameTime)
    {
        var delta = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - Start;
        if (delta <= 200)
        {
            var frac = delta / 200f;
            CurrentColor = Color.Lerp(ObjectColor, Color.Black, 1f - frac);
        }
        
        base.Update(gameTime);
    }
    
    public override void Draw(GameTime gameTime)
        => ObjectShape.Draw(Game.SpriteBatch, gameTime, CurrentColor);
}