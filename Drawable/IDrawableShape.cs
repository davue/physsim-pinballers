using Microsoft.Xna.Framework;
using Pinballers.Physics.Shapes;

namespace Pinballers.Drawable
{
    /// <summary>
    /// This interface is here to have covariance.
    /// </summary>
    /// <remarks><c>S is T</c> means <c>IDrawableShape&lt;S&gt; is IDrawableShape&lt;T&gt;</c></remarks>
    public interface IDrawableShape<out T> where T : Shape
    {
        Color ObjectColor { get; }
        T Shape { get; }
        void Draw(GameTime gameTime);
    }
}
