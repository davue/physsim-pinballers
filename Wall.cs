using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers;

public class Wall : BarObject
{
    private readonly Line _line;

    // Wall attributes
    private readonly float _angle;

    // Stuff for drawing
    private readonly Texture2D _wallTexture;
    private readonly Texture2D _wallEndingTexture;

    public Wall(PinballGame game, Vector2 start, Vector2 end, int radius) : base(game, start, end)
    {
        _line = new Line(start, end, radius);

        // Create wall texture which is just a single white pixel
        _wallTexture = Utils.CreatePointTexture(game.GraphicsDevice);

        // Create a circle texture for the wall ending to create a capsule shape
        _wallEndingTexture = Utils.CreateCircleTexture(GraphicsDevice, 100);

        // Calculate angle
        _angle = (float)Math.Atan2(_line.Direction.Y, _line.Direction.X);

        // Initialize physics
        InitPhysics(_line, ObjectType.Static);
    }

    public override void Draw(GameTime gameTime)
    {
        // Draw rectangle part of capsule
        Game.SpriteBatch.DrawRotating(_wallTexture, Start, Length, _line.Radius, _angle, Color.Black);

        // Draw endings of capsule
        Game.SpriteBatch.DrawCentered(_wallEndingTexture, Start, _line.Radius, Color.Black);
        Game.SpriteBatch.DrawCentered(_wallEndingTexture, End, _line.Radius, Color.Black);
    }
}