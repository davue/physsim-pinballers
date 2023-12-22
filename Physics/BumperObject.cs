﻿using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers.Physics;

public abstract class BumperObject<T> : SimulatedShape<T> where T : Shape
{
    public long Start { get; private set; }
    public Vector2 Center { get; }
    public float BumpForce { get; }

    public BumperObject(PinballGame game, Vector2 center, float bumpForce) : base(game)
    {
        BumpForce = bumpForce;
        Center = center;
    }

    public void Bump()
        => Start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
}