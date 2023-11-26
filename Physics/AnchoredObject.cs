using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers.Physics
{
    public class AnchoredObject : SimulatedObject
    {
        public Vector2 Center { get; }
        public int Length { get; }
        public float CurrentAngularVelocity { get; private set; }
        public double Mass { get; private set; }
        public float Angle => _restAngle + _sign * Rotation;
        public Vector2 EndPosition => Center + Utils.ToCartesian(Length, Angle);

        private readonly float _restAngle;
        private readonly float _maxRotation;
        private readonly int _sign;
        private readonly float _angularVelocity = 0.05f;

        private float Rotation = 0;
        public float TouchIdentifier = 0;

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
            var rotationChange = _angularVelocity * gameTime.ElapsedGameTime.Milliseconds;

            if (TouchIdentifier >= 0)
                Rotation = Math.Min(Rotation + rotationChange, _maxRotation);
            else
                Rotation = Math.Max(Rotation - rotationChange, 0.0f);

            CurrentAngularVelocity = _sign * (Rotation - prevRotation) / gameTime.ElapsedGameTime.Milliseconds;
        }

        public override void InitPhysics(Shape shape, ObjectType objectType)
        {
            base.InitPhysics(shape, objectType);
            Mass = Shape.GetMass();
        }
    }
}
