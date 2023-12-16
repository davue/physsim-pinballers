using Microsoft.Xna.Framework;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers;

public class Bumper : BumperObject<Circle>
{
    public override Color ObjectColor => Color.CornflowerBlue;
    public override ObjectType Type => ObjectType.Static;
    public override Circle Shape { get; }
    
    public Bumper(PinballGame game, Vector2 center, float bumpForce) : base(game, center, bumpForce)
    {
        Shape = new Circle(center, 15);
    }
}