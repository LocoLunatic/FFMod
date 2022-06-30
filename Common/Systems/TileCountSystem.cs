using FFMod.Content.Tiles.Biomes.Madness;
using System;
using Terraria.ModLoader;

namespace FFMod.Common.Systems 
{
    public class TileCountSystem : ModSystem
    {
        public int MadnessTileCount { get; set; }

        public override void ResetNearbyTileEffects()
        {
            MadnessTileCount = 0;
        }

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            MadnessTileCount = tileCounts[ModContent.TileType<MadGrass>()]
                + tileCounts[ModContent.TileType<MadDirt>()];
        }
    }
}
