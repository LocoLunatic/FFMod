using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace FFMod.Utilities.Extensions
{
    public static class Texture2DExtensions
    {
        public static Vector2 GetCenter(this Texture2D texture) => texture.Size() / 2f;
    }
}