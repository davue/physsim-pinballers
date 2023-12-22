using Microsoft.Xna.Framework;
using Pinballers.Helpers;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers.Physics
{
    public abstract class AnchoredObject<T> : SimulatedShape<T>, IAnchoredObject<T> where T : Shape
    {
        public Vector2 Center { get; }
        public int Length { get; }
        public float CurrentAngularVelocity { get; private set; }
        public float Angle => _restAngle + _sign * Rotation;
        public Vector2 EndPosition => Center + Utils.ToCartesian(Length, Angle);
        public abstract float TouchIdentifier { get; set; }

        protected abstract float AngularVelocity { get; }

        private readonly float _restAngle;
        private readonly float _maxRotation;
        private readonly int _sign;

        private float Rotation = 0;

        public AnchoredObject(
            PinballGame game,
            Vector2 center,
            int length,
            float restAngle,
            float maxRotation) : base(game)
        {
            Center = center;
            Length = length;
            _restAngle = restAngle;
            _maxRotation = Math.Abs(maxRotation);
            _sign = Math.Sign(maxRotation);
        }

        public override void Update(GameTime gameTime)
        {
            var prevRotation = Rotation;
            var rotationChange = AngularVelocity * gameTime.ElapsedGameTime.Milliseconds;

            // -1 go to 0
            // 0 spin wildly
            // 1 go to limit
            Rotation = TouchIdentifier switch
            {
                -1 => Rotation = Math.Max(Rotation - rotationChange, 0.0f),
                0 => Rotation + rotationChange,
                1 => Math.Min(Rotation + rotationChange, _maxRotation),
                _ => throw new InvalidOperationException($"Illegal {nameof(AnchoredObject<T>)}<{typeof(T).Name}>.{nameof(TouchIdentifier)}: {TouchIdentifier}")
            };

            CurrentAngularVelocity = -_sign * (Rotation - prevRotation) / gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
