﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers;

public class Wall : SimulatedObject
{
    private readonly PinballGame _pinballGame;
    
    // Wall attributes
    private readonly Vector2 _start;
    private readonly Vector2 _end;
    private int _radius;
    private float _angle;
    
    // Stuff for drawing
    private Rectangle _destRect;
    private Texture2D _wallTexture;
    private Texture2D _wallEndingTexture;
    
    public Wall(PinballGame game, Vector2 start, Vector2 end, int radius) : base(game)
    {
        _radius = radius;
        _pinballGame = game;
        _start = start;
        _end = end;

        var capsule = new Capsule(_start, _end, _radius);

        // Create wall texture which is just a single white pixel
        _wallTexture = new Texture2D(game.GraphicsDevice, 1, 1);
        _wallTexture.SetData(new[] { Color.White });
        
        // Create a circle texture for the wall ending to create a capsule shape
        _wallEndingTexture = Utils.CreateCircleTexture(GraphicsDevice, 100);
        
        // Calculate angle
        _angle = (float)Math.Atan(capsule.Direction.Y / capsule.Direction.X);
        
        // Create destination rectangle
        _destRect = new Rectangle((int)start.X, (int)start.Y, (int)capsule.Length, _radius * 2);
        
        // Initialize physics
        InitPhysics(capsule, ObjectType.Static);
    }

    public override void Draw(GameTime gameTime)
    {
        // Draw rectangle part of capsule
        _pinballGame.SpriteBatch.Draw(_wallTexture, _destRect, null, Color.Black, _angle,
            new Vector2(0, 0.5f), SpriteEffects.None, 0);
        
        // Draw endings of capsule
        _pinballGame.SpriteBatch.Draw(_wallEndingTexture,
            new Rectangle((int)_start.X - _radius, (int)_start.Y - _radius, _radius * 2, _radius * 2), Color.Black);
        _pinballGame.SpriteBatch.Draw(_wallEndingTexture,
            new Rectangle((int)_end.X - _radius, (int)_end.Y - _radius, _radius * 2, _radius * 2), Color.Black);
    }
}