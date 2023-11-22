using Microsoft.Xna.Framework;

namespace Pinballers.Physics.Shapes;

public class Circle : Shape
{
    public Vector2 Center;
    public int Radius;

    public Circle(Vector2 position, int radius)
    {
        Center = position;
        Radius = radius;
    }

    public override bool CheckCollision(Shape second)
    {
        switch (second)
        {
            case Circle:
                throw new System.NotImplementedException();
            case Capsule:
                throw new System.NotImplementedException();
        }

        return false;
    }
}