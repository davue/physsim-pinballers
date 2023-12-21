using Microsoft.Xna.Framework;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers.Helpers;

public abstract class DebugObject<T> : SimulatedShape<T> where T : Shape
{
    public sealed override Color ObjectColor => new Color(_color, Alpha);
    public sealed override ObjectType Type => ObjectType.Effect;

    public long Start { get; }
    public int Duration { get; }
    public long End { get; }
    
    public long Remaining => End - Time;
    public float Alpha => Remaining / Duration;

    private static long Time => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    private readonly Color _color;

    public DebugObject(PinballGame game, int duration, Color color) : base(game)
    {
        Duration = duration;
        Start = Time;
        End = Start + duration;
        _color = color;
    }

    public sealed override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);

        if (Time >= End)
            Dispose();
    }
}