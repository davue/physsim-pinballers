using Microsoft.Xna.Framework;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers;

public class Wall : BarObject<Line>
{
    public override Line Shape { get; }
    public override Color ObjectColor => Color.Black;
    public override ObjectType Type => ObjectType.Static;

    public Wall(PinballGame game, Vector2 start, Vector2 end, int radius) : base(game, start, end)
        => Shape = new Line(start, end, radius);
}