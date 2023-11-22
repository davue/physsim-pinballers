using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pinballers.Physics;

namespace Pinballers;

public class PinballGame : Game
{
    private GraphicsDeviceManager _graphics;
    public SpriteBatch SpriteBatch;
    public List<SimulatedObject> SimulatedObjects = new();
    public Vector2 Gravity = new(0, 0.03f);

    public PinballGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 400;
        _graphics.PreferredBackBufferHeight = 800;
        _graphics.ApplyChanges();

        // Create level walls
        Components.Add(new Wall(this, new Vector2(10, 10), new Vector2(10, 600), 10));
        Components.Add(new Wall(this, new Vector2(10, 600), new Vector2(100, 700), 10));
        Components.Add(new Wall(this, new Vector2(100, 700), new Vector2(100, 790), 10));
        Components.Add(new Wall(this, new Vector2(100, 790), new Vector2(300, 790), 10));
        Components.Add(new Wall(this, new Vector2(300, 790), new Vector2(300, 700), 10));
        Components.Add(new Wall(this, new Vector2(300, 700), new Vector2(390, 600), 10));
        Components.Add(new Wall(this, new Vector2(390, 600), new Vector2(390, 10), 10));
        Components.Add(new Wall(this, new Vector2(10, 10), new Vector2(390, 10), 10));

        // Create ball
        Components.Add(new Ball(this, new Vector2(300, 500), 15));

        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        // Close game on escape
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Update everything else
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Set background color
        GraphicsDevice.Clear(Color.White);

        // Use one SpriteBatch to draw everything
        SpriteBatch.Begin();
        base.Draw(gameTime);
        SpriteBatch.End();
    }
}