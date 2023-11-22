using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pinballers;

public class Wall : DrawableGameComponent
{
    private readonly PinballGame _pinballGame;
    
    // Wall attributes
    private int _radius;
    private float _length;
    private Vector2 _direction;
    private Vector2 _normal;
    private float _angle;
    
    // Stuff for drawing
    private Rectangle _destRect;
    private Texture2D _wallTexture;
    
    public Wall(PinballGame game, Vector2 start, Vector2 end, int radius) : base(game)
    {
        _radius = radius;
        _pinballGame = game;
        
        // Calculate direction vector and length
        _direction = end - start;
        _length = _direction.Length();
        
        // Copy direction vector and normalize it
        _normal = new Vector2(_direction.X, _direction.Y);
        _normal.Normalize();
        
        // Create wall texture which is just a single white pixel
        _wallTexture = new Texture2D(game.GraphicsDevice, 1, 1);
        _wallTexture.SetData(new[] { Color.Black });
        
        // Calculate angle
        _angle = (float)Math.Atan(_direction.Y / _direction.X);
        
        // Create destination rectangle
        _destRect = new Rectangle((int)start.X, (int)start.Y, (int)_length, _radius * 2);
    }

    public override void Draw(GameTime gameTime)
    {
        _pinballGame.spriteBatch.Draw(_wallTexture, _destRect, null, Color.Black, _angle,
            new Vector2(0, 0.5f), SpriteEffects.None, 0);
    }
}