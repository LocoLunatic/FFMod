using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.WorldBuilding;

namespace FFMod.Utilities
{
    public static class WorldGenUtils
    {
        public static int WorldSize => Main.maxTilesX switch
        {
            <= 4200 => 1,
            <= 6400 => 2,
            <= 8400 => 3,
            _ => 1
        };

        public static bool IsValidPlacement(Point point, GenShape scanShape, int scanType, int minimumAmount)
        {
            Dictionary<ushort, int> tileCount = new();

            WorldUtils.Gen(point, scanShape, new Actions.TileScanner((ushort)scanType).Output(tileCount));

            return tileCount[(ushort)scanType] < minimumAmount;
        }
    }
}
