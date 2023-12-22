using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Drawable;

public class FadingVector : FadingObject<Line>
{
    public override Line Shape { get; }

    public FadingVector(PinballGame game, Vector2 origin, Vector2 direction, float scale, int duration) : base(game, duration, Color.Lime, false)
        => Shape = new Line(origin, origin + direction * scale, 1);
}