using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Physics;

public class SimulatedObject : DrawableGameComponent
{
    protected new readonly PinballGame Game;
    public Shape Shape;
    public ObjectType Type;

    public virtual void InitPhysics(Shape shape, ObjectType objectType)
    {
        Shape = shape;
        Type = objectType;
    }
    
    public SimulatedObject(PinballGame game) : base(game)
    {
        Game = game;
        Game.SimulatedObjects.Add(this);
    }

    public Collision GetCollision(SimulatedObject second)
    {
        return Shape.GetCollision(second.Shape);
    }

    protected override void Dispose(bool disposing)
    {
        Game.SimulatedObjects.Remove(this);
        Game.Components.Remove(this);
        base.Dispose(disposing);
    }
}