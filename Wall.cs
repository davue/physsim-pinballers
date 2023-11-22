using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pinballers;

public class Wall : DrawableGameComponent
{
    private readonly PinballGame _pinballGame;
    private readonly Vector2 _start;
    private readonly Vector2 _end;

    // Wall attributes
    private int _radius;
    private float _length;
    private Vector2 _direction;
    private Vector2 _normal;
    private float _angle;
    
    // Stuff for drawing
    private Rectangle _destRect;
    private Texture2D _wallTexture;
    private Texture2D _wallEndingTexture;
    
    // Copied from https://stackoverflow.com/questions/2519304/draw-simple-circle-in-xna
    private Texture2D CreateCircleTexture(int dia)
    {
        Texture2D texture = new Texture2D(GraphicsDevice, dia, dia);
        Color[] colorData = new Color[dia*dia];

        float r = dia / 2f;
        float rSqr = r * r;

        for (int x = 0; x < dia; x++)
        {
            for (int y = 0; y < dia; y++)
            {
                int index = x * dia + y;
                Vector2 pos = new Vector2(x - r, y - r);
                if (pos.LengthSquared() <= rSqr)
                {
                    colorData[index] = Color.White;
                }
                else
                {
                    colorData[index] = Color.Transparent;
                }
            }
        }

        texture.SetData(colorData);
        return texture;
    }
    
    public Wall(PinballGame game, Vector2 start, Vector2 end, int radius) : base(game)
    {
        _radius = radius;
        _pinballGame = game;
        _start = start;
        _end = end;

        // Calculate direction vector and length
        _direction = end - start;
        _length = _direction.Length();
        
        // Copy direction vector and normalize it
        _normal = new Vector2(_direction.X, _direction.Y);
        _normal.Normalize();
        
        // Create wall texture which is just a single white pixel
        _wallTexture = new Texture2D(game.GraphicsDevice, 1, 1);
        _wallTexture.SetData(new[] { Color.White });
        
        // Create a circle texture for the wall ending to create a capsule shape
        _wallEndingTexture = CreateCircleTexture(100);
        
        // Calculate angle
        _angle = (float)Math.Atan(_direction.Y / _direction.X);
        
        // Create destination rectangle
        _destRect = new Rectangle((int)start.X, (int)start.Y, (int)_length, _radius * 2);
    }

    public override void Draw(GameTime gameTime)
    {
        // Draw rectangle part of capsule
        _pinballGame.spriteBatch.Draw(_wallTexture, _destRect, null, Color.Black, _angle,
            new Vector2(0, 0.5f), SpriteEffects.None, 0);
        
        // Draw endings of capsule
        _pinballGame.spriteBatch.Draw(_wallEndingTexture,
            new Rectangle((int)_start.X - _radius, (int)_start.Y - _radius, _radius * 2, _radius * 2), Color.Black);
        _pinballGame.spriteBatch.Draw(_wallEndingTexture,
            new Rectangle((int)_end.X - _radius, (int)_end.Y - _radius, _radius * 2, _radius * 2), Color.Black);
    }
}