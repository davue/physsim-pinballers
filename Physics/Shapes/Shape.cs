﻿using System;
using Microsoft.Xna.Framework;

namespace Pinballers.Physics.Shapes;

public abstract class Shape
{
    public virtual bool CheckCollision(Shape second)
    {
        throw new NotImplementedException();
    }
    
    public virtual Vector2? GetCollisionNormal(Shape second)
    {
        throw new NotImplementedException();
    }
    
    public virtual Vector2 GetClosestPointOnSurface(Shape second)
    {
        throw new NotImplementedException();
    }

    public virtual double GetMass()
    {
        throw new NotImplementedException();
    }
}