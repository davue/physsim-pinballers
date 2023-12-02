using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pinballers.Helpers;
using Pinballers.Physics;
using System;
using System.Collections.Generic;

namespace Pinballers;

public class PinballGame : Game
{
    // Framework fields
    private const int TargetFrameRate = 144;
    private GraphicsDeviceManager _graphics;
    public SpriteBatch SpriteBatch;

    // Simulation fields
    public List<SimulatedObject> SimulatedObjects = new();
    public Vector2 Gravity = new(0, 0.003f);
    private Ball _ball;
    private Flipper _leftFlipper;
    private Flipper _rightFlipper;

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

        // Create textures once globally
        TextureHelper.InitTextures(GraphicsDevice);

        // Create level walls
        Components.Add(new Wall(this, new Vector2(10, 10), new Vector2(10, 550), 5));
        Components.Add(new Wall(this, new Vector2(10, 550), new Vector2(100, 650), 5));
        Components.Add(new Wall(this, new Vector2(100, 650), new Vector2(100, 790), 5));
        Components.Add(new Wall(this, new Vector2(100, 790), new Vector2(300, 790), 5));
        Components.Add(new Wall(this, new Vector2(300, 790), new Vector2(300, 650), 5));
        Components.Add(new Wall(this, new Vector2(300, 650), new Vector2(390, 550), 5));
        Components.Add(new Wall(this, new Vector2(390, 550), new Vector2(390, 10), 5));
        Components.Add(new Wall(this, new Vector2(390, 10), new Vector2(10, 10), 5));

        // Add obstacles to the game
        Components.Add(new Obstacle(this, new Vector2(120, 140), new Vector2(160, 180), 5));
        Components.Add(new Obstacle(this, new Vector2(280, 140), new Vector2(240, 180), 5));
        Components.Add(new Obstacle(this, new Vector2(80, 440), new Vector2(120, 480), 5));
        Components.Add(new Obstacle(this, new Vector2(320, 440), new Vector2(280, 480), 5));

        // Create ball
        _ball = new Ball(this, new Vector2(20, 200), 15);
        Components.Add(_ball);

        // Initialize Debug Utils
        DebugUtils = new DebugUtils(this);

        // Initialize mouse state
        _lastMouseState = Mouse.GetState();

        // Create flipper
        _leftFlipper = new Flipper(this, new Vector2(100, 655), 10, 70, -(float)(Math.PI / 4), (float)(Math.PI / 2));
        _rightFlipper = new Flipper(this, new Vector2(300, 655), 10, 70, 3 * -(float)(Math.PI / 4),
            (float)(-Math.PI / 2));
        Components.Add(_leftFlipper);
        Components.Add(_rightFlipper);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        // Close game on escape
        var keyboardState = Keyboard.GetState();
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            keyboardState.IsKeyDown(Keys.Escape))
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

        // Flipper controls
        if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
        {
            _leftFlipper.TouchIdentifier = 1;
        }
        else
        {
            _leftFlipper.TouchIdentifier = -1;
        }
        if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
        {
            _rightFlipper.TouchIdentifier = 1;
        }
        else
        {
            _rightFlipper.TouchIdentifier = -1;
        }

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