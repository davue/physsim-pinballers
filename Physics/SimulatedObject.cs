namespace Pinballers.Physics;

public abstract class SimulatedObject : DrawableObject
{
    public abstract ObjectType Type { get; }

    protected SimulatedObject(PinballGame game) : base(game)
        => Game.SimulatedObjects.Add(this);

    public Collision GetCollision(SimulatedObject second)
        => ObjectShape.GetCollision(second.ObjectShape);

    public double Mass => ObjectShape.GetMass();

    protected override void Dispose(bool disposing)
    {
        Game.SimulatedObjects.Remove(this);
        base.Dispose(disposing);
    }
}