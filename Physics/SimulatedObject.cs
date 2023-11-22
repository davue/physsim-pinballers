using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics;

public class SimulatedObject : DrawableGameComponent
{
    public Shape Shape;
    public ObjectType Type;

    public void InitPhysics(Shape shape, ObjectType objectType)
    {
        Shape = shape;
        Type = objectType;
    }
    
    public SimulatedObject(Game game) : base(game)
    {
    }

    public bool CheckCollision(SimulatedObject second)
    {
        return Shape.CheckCollision(second.Shape);
    }
}