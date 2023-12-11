using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pinballers.Helpers;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers;

public class Flipper : AnchoredObject
{
    private Capsule _shape;

    // Stuff for drawing
    private readonly Texture2D _ballTexture;
    private readonly Texture2D _rectangleTexture;

    public Flipper(PinballGame game, Vector2 startPosition, int radius, int length, float restAngle, float maxRotation) : base(game, startPosition, length, restAngle, maxRotation)
    {
        _shape = new Capsule(startPosition, EndPosition, radius);

        _ballTexture = Utils.CreateCircleTexture(game.GraphicsDevice, 100);
        _rectangleTexture = Utils.CreatePointTexture(game.GraphicsDevice);

        // Initialize Physics
        base.InitPhysics(_shape, ObjectType.Anchored);
    }

    public override void Draw(GameTime gameTime)
    {
        Game.SpriteBatch.DrawCentered(_ballTexture, Center, _shape.Radius, Color.Red);

        Game.SpriteBatch.DrawRotating(_rectangleTexture, Center, _shape.Length, _shape.Radius, Angle, Color.Red);

        Game.SpriteBatch.DrawCentered(_ballTexture, EndPosition, _shape.Radius, Color.Red);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        _shape.End = EndPosition;
    }
}