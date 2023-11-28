using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers;

public class Obstacle : BarObject
{
    private readonly Capsule _capsule;

    // Wall attributes
    private readonly float _angle;

    // Stuff for drawing
    private readonly Texture2D _obstacleTexture;
    private readonly Texture2D _obstacleEndingTexture;

    public Obstacle(PinballGame game, Vector2 start, Vector2 end, int radius) : base(game, start, end)
    {
        _capsule = new Capsule(start, end, radius);

        // Create wall texture which is just a single white pixel
        _obstacleTexture = Utils.CreatePointTexture(game.GraphicsDevice);

        // Create a circle texture for the wall ending to create a capsule shape
        _obstacleEndingTexture = Utils.CreateCircleTexture(GraphicsDevice, 100);

        // Calculate angle
        _angle = (float)Math.Atan2(_capsule.Direction.Y, _capsule.Direction.X);

        // Initialize physics
        InitPhysics(_capsule, ObjectType.Static);
    }

    public override void Draw(GameTime gameTime)
    {
        // Draw rectangle part of capsule
        Game.SpriteBatch.DrawRotating(_obstacleTexture, Start, Length, _capsule.Radius, _angle, Color.Blue);

        // Draw endings of capsule
        Game.SpriteBatch.DrawCentered(_obstacleEndingTexture, Start, _capsule.Radius, Color.Blue);
        Game.SpriteBatch.DrawCentered(_obstacleEndingTexture, End, _capsule.Radius, Color.Blue);
    }
}