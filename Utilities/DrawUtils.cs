using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace FFMod.Utilities
{
    public static class DrawUtils
    {
        public static Rectangle ScreenRectangle => new(0, 0, Main.screenWidth, Main.screenHeight);

        public static Vector2 ScreenSize => new(Main.screenWidth, Main.screenHeight);

        public static Vector2 ScreenCenter => ScreenSize / 2f;

        public static Matrix DefaultEffectMatrix
        {
            get
            {
                GraphicsDevice device = Main.instance.GraphicsDevice;

                float width = device.Viewport.Width > 0 ? 2f / device.Viewport.Width : 0;
                float height = device.Viewport.Height > 0 ? -2f / device.Viewport.Height : 0;

                return new Matrix
                {
                    M11 = width,
                    M22 = height,
                    M33 = 1,
                    M44 = 1,
                    M41 = -1 - width / 2f,
                    M42 = 1 - height / 2f
                };
            }
        }
    }
}
