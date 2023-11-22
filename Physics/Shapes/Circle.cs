using Microsoft.Xna.Framework;

namespace Pinballers.Physics.Shapes;

public class Circle : Shape
{
    private Vector2 _position;
    private int _radius;

    public Circle(Vector2 position, int radius)
    {
        Type = ShapeType.Circle;
        _position = position;
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