using Microsoft.Xna.Framework;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers
{
    public class Spinner : AnchoredObject<Cross>
    {
        public override Cross Shape { get; }
        public override Color ObjectColor => Color.Red;
        public override ObjectType Type => ObjectType.Anchored;

        public override float TouchIdentifier { get; set; } = 0;
        protected override float AngularVelocity => 0.01f;

        public Spinner(PinballGame game, Vector2 startPosition, int radius, int length, float restAngle, int rotationSign) : base(game, startPosition, length, restAngle, rotationSign)
            => Shape = new Cross(startPosition, EndPosition, radius);

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Shape.Angle = Angle;
            Shape.East = EndPosition;
        }
    }
}
