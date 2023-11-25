using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers;

public class Flipper : AnchoredObject
{
    private Capsule _shape;

    // Stuff for drawing
    private Texture2D _ballTexture;
    private Texture2D _rectangleTexture;

    public Flipper(PinballGame game, Vector2 startPosition, Vector2 endPosition, int radius, float maxRotation) : base(game, startPosition, endPosition - startPosition, maxRotation)
    {
        _shape = new Capsule(startPosition, endPosition, radius);
        
        float length = (endPosition - startPosition).Length();

        _ballTexture = Utils.CreateCircleTexture(game.GraphicsDevice, 100);
        _rectangleTexture = Utils.CreateRectangleTexture(game.GraphicsDevice, (int) length, radius);

        // Initialize Physics
        base.InitPhysics(_shape, ObjectType.Anchored);
    }

    public override void Draw(GameTime gameTime)
    {
        Game.SpriteBatch.DrawCentered(_ballTexture, Center, _shape.Radius, Color.Red);

        Game.SpriteBatch.DrawRotating(_rectangleTexture, Center, (int)_shape.Length, _shape.Radius, Angle, Color.Red);

        Game.SpriteBatch.DrawCentered(_ballTexture, EndPosition, _shape.Radius, Color.Red);
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);
}