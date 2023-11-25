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
        Game.SpriteBatch.Draw(_ballTexture,
            new Rectangle((int)Center.X - _shape.Radius, (int)Center.Y - _shape.Radius, _shape.Radius * 2, _shape.Radius * 2),
            Color.Red);

        Game.SpriteBatch.Draw(_rectangleTexture,
            Center,
            new Rectangle((int)Center.X, (int)Center.Y, (int)_shape.Length, _shape.Radius * 2),
            Color.Red,
            Angle,
            new Vector2(0, _shape.Radius),
            1,
            SpriteEffects.None,
            1);

        Game.SpriteBatch.Draw(_ballTexture,
            new Rectangle((int)EndPosition.X - _shape.Radius, (int)EndPosition.Y - _shape.Radius, _shape.Radius * 2, _shape.Radius * 2),
            Color.Red);
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);
}