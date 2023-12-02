using Microsoft.Xna.Framework;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers;

public class Flipper : AnchoredObject<Capsule>
{
    public override Capsule Shape { get; }
    public override Color ObjectColor => Color.Red;
    public override ObjectType Type => ObjectType.Anchored;

    public Flipper(PinballGame game, Vector2 startPosition, int radius, int length, float restAngle, float maxRotation) : base(game, startPosition, length, restAngle, maxRotation)
        => Shape = new Capsule(startPosition, EndPosition, radius);

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        Shape.Angle = Angle;
        Shape.End = EndPosition;
    }
}