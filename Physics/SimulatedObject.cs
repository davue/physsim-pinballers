using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics;

public class SimulatedObject : DrawableGameComponent
{
    public Shape Shape;
    public ObjectType Type;
    
    // Other properties needed for physical simulation
    public Vector2 Velocity;

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