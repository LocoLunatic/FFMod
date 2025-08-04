using Microsoft.Xna.Framework;
using Terraria;

namespace FFMod.Utilities.Extensions
{
    public static class RectangleExtensions
    {
        public static Point GetRandomPoint(this Rectangle rectangle)
        {
            Point random = new(Main.rand.Next(rectangle.Width), Main.rand.Next(rectangle.Height));
            Point position = rectangle.TopLeft().ToPoint() + random;

            return position;
        }

        public static Vector2 GetPosition(this Rectangle rectangle) => new(rectangle.X, rectangle.Y);

        public static Vector2 ToDrawPosition(this Rectangle rectangle) => rectangle.GetPosition() - Main.screenPosition;
    }
}