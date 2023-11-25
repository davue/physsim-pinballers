using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pinballers.Physics.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pinballers
{
    public static class SpriteBatchExtension
    {
        public static void DrawCentered(this SpriteBatch spriteBatch, Texture2D texture, Vector2 center, int radius, Color color)
            => spriteBatch.Draw(
                texture,
                new Rectangle((int) center.X - radius, (int) center.Y - radius, radius * 2, radius * 2),
                Color.Red);
    }
}
