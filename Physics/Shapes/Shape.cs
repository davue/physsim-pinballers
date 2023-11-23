using System;
using Microsoft.Xna.Framework;

namespace Pinballers.Physics.Shapes;

public abstract class Shape
{
    public virtual Collision GetCollision(Shape second)
    {
        throw new NotImplementedException();
    }

    public virtual double GetMass()
    {
        throw new NotImplementedException();
    }
}