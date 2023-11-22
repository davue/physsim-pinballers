using Microsoft.Xna.Framework;

namespace Pinballers.Physics.Shapes;

public class Capsule : Shape
{
    private Vector2 _start;
    private Vector2 _end;
    private int _radius;

    public Capsule(Vector2 start, Vector2 end, int radius)
    {
        Type = ShapeType.Capsule;
        _start = start;
        _end = end;
        _radius = radius;
    }

    public override bool CheckCollision(Shape second)
    {
        switch (second.Type)
        {
            case ShapeType.Circle:
                throw new System.NotImplementedException();
            case ShapeType.Capsule:
                throw new System.NotImplementedException();
        }

        return false;
    }
}