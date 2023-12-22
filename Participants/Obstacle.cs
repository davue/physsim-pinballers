using Microsoft.Xna.Framework;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers.Participants;

public class Obstacle : SimulatedShape<Capsule>
{
    public override Capsule Shape { get; }
    public override Color ObjectColor => Color.Blue;
    public override ObjectType Type => ObjectType.Static;

    public Obstacle(PinballGame game, Vector2 start, Vector2 end, int radius) : base(game)
        => Shape = new Capsule(start, end, radius);
}