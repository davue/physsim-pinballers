using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Helpers;

public class FadingPoint : DebugObject<Circle>
{
    public override Circle Shape { get; }

    public FadingPoint(PinballGame game, Vector2 position, int radius, int duration) : base(game, duration, Color.Blue)
        => Shape = new Circle(position, radius);
}