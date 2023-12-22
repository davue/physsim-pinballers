using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Drawable
{
    /// <summary>
    /// Drawn <typeparamref name="T"/> that doesn't participate in the physics simulation
    /// </summary>
    /// <remarks>Constructor auto-adds to game</remarks>
    public abstract class DrawableShape<T> : DrawableGameComponent, IDrawableShape<T> where T : Shape
    {
        protected new PinballGame Game { get; }
        public abstract Color ObjectColor { get; }
        public abstract T Shape { get; }

        protected DrawableShape(PinballGame game) : base(game)
        {
            Game = game;
            Game.Components.Add(this);
        }

        public override void Draw(GameTime gameTime)
            => Shape.Draw(Game.SpriteBatch, gameTime, ObjectColor);

        protected override void Dispose(bool disposing)
        {
            Game.Components.Remove(this);
            base.Dispose(disposing);
        }
    }
}
