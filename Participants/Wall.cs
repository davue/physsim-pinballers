using Microsoft.Xna.Framework;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers.Participants;

public class Wall : SimulatedShape<Line>
{
    public override Line Shape { get; }
    public override Color ObjectColor => Color.Black;
    public override ObjectType Type => ObjectType.Static;

    public Wall(PinballGame game, Vector2 start, Vector2 end, int radius) : base(game)
        => Shape = new Line(start, end, radius);
}