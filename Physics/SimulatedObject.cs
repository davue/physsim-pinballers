using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics;

public class SimulatedObject : DrawableGameComponent
{
    public Shape Shape;
    public ObjectType Type;

    public virtual void InitPhysics(Shape shape, ObjectType objectType)
    {
        Shape = shape;
        Type = objectType;
    }
    
    public SimulatedObject(Game game) : base(game)
    {
    }

    public Vector2? GetCollisionNormal(SimulatedObject second)
    {
        return Shape.GetCollisionNormal(second.Shape);
    }
}