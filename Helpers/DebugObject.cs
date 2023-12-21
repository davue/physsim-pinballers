using Microsoft.Xna.Framework;
using Pinballers.Drawable;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers.Helpers;

public abstract class DebugObject<T> : DrawableShape<T> where T : Shape
{
    public sealed override Color ObjectColor => new Color(_color, Alpha);

    public long Start { get; }
    public int Duration { get; }
    public long End { get; }

    public long Remaining => End - Time;
    public float Alpha => _decay ? Remaining / Duration : 1;

    private static long Time => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    private readonly Color _color;
    private readonly bool _decay;

    public DebugObject(PinballGame game, int duration, Color color) : this(game, duration, color, true) { }

    public DebugObject(PinballGame game, int duration, Color color, bool decay) : base(game)
    {
        Duration = duration;
        Start = Time;
        End = Start + duration;
        _color = color;
        _decay = decay;
    }

    public sealed override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);

        if (Time >= End)
            Dispose();
    }
}