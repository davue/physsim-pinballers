using Microsoft.Xna.Framework.Graphics;

namespace Pinballers.Helpers
{
    public static class TextureHelper
    {
        public static void InitTextures(GraphicsDevice graphicsDevice)
        {
            Circle = Utils.CreateCircleTexture(graphicsDevice, 100);
            Point = Utils.CreatePointTexture(graphicsDevice);
        }

        public static Texture2D Circle { get; private set; }
        public static Texture2D Point { get; private set; }
    }
}
