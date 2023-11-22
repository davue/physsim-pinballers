using System;

namespace Pinballers.Physics.Shapes;

public abstract class Shape
{
    public virtual bool CheckCollision(Shape second)
    {
        throw new NotImplementedException();
    }

    public virtual double GetMass()
    {
        throw new NotImplementedException();
    }
}