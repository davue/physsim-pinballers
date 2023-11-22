using System;

namespace Pinballers.Physics.Shapes;

public class Shape
{
    public ShapeType Type = ShapeType.None;

    public virtual bool CheckCollision(Shape second)
    {
        throw new NotImplementedException();
    }
}