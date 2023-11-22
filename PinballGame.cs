using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pinballers;

public class PinballGame : Game
{
    private GraphicsDeviceManager _graphics;
    public SpriteBatch spriteBatch;
    
    
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
        Components.Add(new Wall(this, new Vector2(10, 10), new Vector2(10, 600), 5));
        Components.Add(new Wall(this, new Vector2(10, 600), new Vector2(100, 700), 5));
        Components.Add(new Wall(this, new Vector2(100, 700), new Vector2(100, 790), 5));
        Components.Add(new Wall(this, new Vector2(100, 790), new Vector2(300, 790), 5));
        Components.Add(new Wall(this, new Vector2(300, 790), new Vector2(300, 700), 5));
        Components.Add(new Wall(this, new Vector2(300, 700), new Vector2(390, 600), 5));
        Components.Add(new Wall(this, new Vector2(390, 600), new Vector2(390, 10), 5));
        Components.Add(new Wall(this, new Vector2(10, 10), new Vector2(390, 10), 5));
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var mouseState = Mouse.GetState();
        Console.WriteLine(mouseState);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        spriteBatch.Begin();
        base.Draw(gameTime);
        spriteBatch.End();
    }
}
