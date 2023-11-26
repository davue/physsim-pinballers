using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pinballers.Helpers;
using Pinballers.Physics;
using Pinballers.Physics.Shapes;

namespace Pinballers;

public class PinballGame : Game
{
    // Framework fields
    private const int TargetFrameRate = 144;
    private GraphicsDeviceManager _graphics;
    public SpriteBatch SpriteBatch;
    
    // Simulation fields
    public List<SimulatedObject> SimulatedObjects = new();
    public Vector2 Gravity = new(0, 0.005f);
    private Ball _ball;

    // Other
    public DebugUtils DebugUtils;
    private MouseState _lastMouseState;

    public PinballGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // Set window size
        _graphics.PreferredBackBufferWidth = 400;
        _graphics.PreferredBackBufferHeight = 800;
        _graphics.ApplyChanges();
        
        // Set target framerate
        var temp = 1000d / TargetFrameRate * 10000d;
        TargetElapsedTime = new TimeSpan((long)temp);

        // Create level walls
        Components.Add(new Wall(this, new Vector2(10, 10), new Vector2(10, 600), 5));
        Components.Add(new Wall(this, new Vector2(10, 600), new Vector2(100, 700), 5));
        Components.Add(new Wall(this, new Vector2(100, 700), new Vector2(100, 790), 5));
        Components.Add(new Wall(this, new Vector2(100, 790), new Vector2(300, 790), 5));
        Components.Add(new Wall(this, new Vector2(300, 790), new Vector2(300, 700), 5));
        Components.Add(new Wall(this, new Vector2(300, 700), new Vector2(390, 600), 5));
        Components.Add(new Wall(this, new Vector2(390, 600), new Vector2(390, 10), 5));
        Components.Add(new Wall(this, new Vector2(10, 10), new Vector2(390, 10), 5));

        // Create ball
        _ball = new Ball(this, new Vector2(20, 200), 15);
        Components.Add(_ball);

        // Initialize Debug Utils
        DebugUtils = new DebugUtils(this);

        // Initialize mouse state
        _lastMouseState = Mouse.GetState();

        // Create flipper
        Components.Add(new Flipper(this, new Vector2(110, 700), 15, 50, (float)(Math.PI / 4), (float) (- Math.PI / 2)));

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
        
        // Create new ball at mouse position on click
        var currentMouseState = Mouse.GetState();
        if (_lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
        {
            _ball.Dispose();
            _ball = new Ball(this, currentMouseState.Position.ToVector2(), 15);
            Components.Add(_ball);
        }
        _lastMouseState = currentMouseState;

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