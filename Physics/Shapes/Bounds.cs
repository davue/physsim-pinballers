using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pinballers.Physics.Shapes
{
    public class Bounds : Shape
    {
        public IEnumerable<Line> Lines { get; }

        public Bounds(IEnumerable<Line> lines)
            => Lines = lines;
        
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color) { }
    }
}
