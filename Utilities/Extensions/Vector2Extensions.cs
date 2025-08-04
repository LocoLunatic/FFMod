using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace FFMod.Utilities.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 ToDrawPosition(this Vector2 vector) => vector - Main.screenPosition;

        public static Vector2 GetMiddleBetween(this Vector2 start, Vector2 end) => (start + end) / 2f;

        public static Vector3 ToVector3(this Vector2 vector) => new(vector.X, vector.Y, 0f);

        public static Vector2 Abs(this Vector2 vector) => new(MathF.Abs(vector.X), MathF.Abs(vector.Y));
    }
}