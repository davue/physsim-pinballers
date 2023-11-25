using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers.Physics
{
    public class AnchoredObject : SimulatedObject
    {
        protected new readonly PinballGame Game;

        public Vector2 Center { get; }
        public float Length { get; }
        public float CurrentAngularVelocity { get; private set; }
        public double Mass { get; private set; }
        public float Angle => RestAngle + Sign * Rotation;
        public Vector2 EndPosition => Center + Utils.ToCartesian(Length, Angle);

        private readonly float RestAngle;
        private readonly float MaxRotation;
        private readonly int Sign;

        private float AngularVelocity = 0.001f;
        public float TouchIdentifier = 1;
        private float Rotation = 0;

        public AnchoredObject(
            PinballGame game,
            Vector2 center,
            Vector2 direction,
            float maxRotation) : this(game, center, direction.Length(), Utils.Angle(direction), maxRotation) { }

        public AnchoredObject(
            PinballGame game,
            Vector2 center,
            float length,
            float restAngle,
            float maxRotation) : base(game)
        {
            Game = game;
            Center = center;
            Length = length;
            RestAngle = restAngle;
            MaxRotation = Math.Abs(maxRotation);
            Sign = Math.Sign(maxRotation);
        }

        public override void Update(GameTime gameTime)
        {
            var prevRotation = Rotation;
            var rotationChange = AngularVelocity * gameTime.ElapsedGameTime.Milliseconds;

            if (TouchIdentifier >= 0)
                Rotation = Math.Min(Rotation + rotationChange, MaxRotation);
            else
                Rotation = Math.Max(Rotation - rotationChange, 0.0f);

            CurrentAngularVelocity = Sign * (Rotation - prevRotation) / gameTime.ElapsedGameTime.Milliseconds;
        }

        public override void InitPhysics(Shape shape, ObjectType objectType)
        {
            base.InitPhysics(shape, objectType);
            Mass = Shape.GetMass();
        }
    }
}
