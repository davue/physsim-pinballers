﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;
using System;

namespace Pinballers;

public class Flipper : AnchoredObject
{
    private Capsule _capsuleShape;

    // Ball attributes
    private int _radius;

    // Stuff for drawing
    private Texture2D _ballTexture;
    private Texture2D _rectangleTexture;

    public Flipper(PinballGame game, Vector2 startPosition, Vector2 endPosition, int radius, float maxRotation) : base(game, startPosition, endPosition - startPosition, maxRotation)
    {
        _capsuleShape = new Capsule(startPosition, endPosition, radius);
        _radius = radius;
        
        float length = (endPosition - startPosition).Length();

        _ballTexture = Utils.CreateCircleTexture(game.GraphicsDevice, radius);
        _rectangleTexture = Utils.CreateRectangleTexture(game.GraphicsDevice, (int) length, radius);

        // Initialize Physics
        base.InitPhysics(_capsuleShape, ObjectType.Anchored);
        Game.SimulatedObjects.Add(this);
    }

    public override void Draw(GameTime gameTime)
    {
        Game.SpriteBatch.Draw(_ballTexture,
            new Rectangle((int)Center.X, (int)Center.Y, _radius * 2, _radius * 2),
            Color.Red);
        
        /* Game.SpriteBatch.Draw(_rectangleTexture,
            new Vector2(Center.X, Center.Y), null,
            Color.Red, Angle, Vector2.Zero, 1, ); */

        Game.SpriteBatch.Draw(_ballTexture,
            new Rectangle((int)EndPosition.X, (int)EndPosition.Y, _radius * 2, _radius * 2),
            Color.Red);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
}