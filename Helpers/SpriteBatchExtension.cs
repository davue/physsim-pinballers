using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pinballers.Helpers
{
    public static class SpriteBatchExtension
    {
        /// <summary>
        /// Draw center of <paramref name="texture"/> at <paramref name="center"/>
        /// </summary>
        public static void DrawCentered(this SpriteBatch spriteBatch, Texture2D texture, Vector2 center, int radius, Color color)
            => spriteBatch.Draw(texture,
                new Rectangle((int)center.X - radius, (int)center.Y - radius, radius * 2, radius * 2),
                color);

        /// <summary>
        /// Draw center of <paramref name="texture"/> at <paramref name="center"/> and rotate it by <paramref name="angle"/>
        /// </summary>
        public static void DrawCenteredRotating(this SpriteBatch spriteBatch, Texture2D texture, Vector2 center, int length, int radius, float angle, Color color)
            => spriteBatch.Draw(texture,
                center,
                new Rectangle((int)center.X, (int)center.Y, length, radius * 2),
                color,
                -angle,
                new Vector2(length / 2, radius),
                1,
                SpriteEffects.None,
                0);

        /// <summary>
        /// Draw edge of <paramref name="texture"/> at <paramref name="center"/> and rotate it by <paramref name="angle"/>
        /// </summary>
        public static void DrawRotating(this SpriteBatch spriteBatch, Texture2D texture, Vector2 center, int length, int radius, float angle, Color color)
            => spriteBatch.Draw(texture,
                center,
                new Rectangle((int)center.X, (int)center.Y, length, radius * 2),
                color,
                -angle,
                new Vector2(0, radius),
                1,
                SpriteEffects.None,
                0);
    }
}
