using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers.Physics;

/// <summary>
/// <typeparamref name="T"/> that pushes colliding objects away with <see cref="BumpForce"/>
/// </summary>
public abstract class BumperObject<T> : SimulatedShape<T> where T : Shape
{
    public long Start { get; private set; }
    public float BumpForce { get; }

    public BumperObject(PinballGame game, Vector2 center, float bumpForce) : base(game)
        => BumpForce = bumpForce;

    public void Bump()
        => Start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
}