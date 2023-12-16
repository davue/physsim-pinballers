using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics;

public abstract class BumperObject<T> : SimulatedShape<T> where T : Shape
{
    public Vector2 Center { get; }
    public float BumpForce { get; }

    public BumperObject(PinballGame game, Vector2 center, float bumpForce) : base(game)
    {
        BumpForce = bumpForce;
        Center = center;
    }
}