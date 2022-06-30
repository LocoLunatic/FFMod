using FFMod.Content.Dusts;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Projectiles.Sprays
{
    public class MadSpray : Spray
    {
        public override int DustType 
			=> ModContent.DustType<MadSolution>();

        public override void SetStaticDefaults() 
			=> DisplayName.SetDefault("Madness Spray");

        public override void Convert(int i, int j, int size = 4)
		{
			for (int k = i - size; k <= i + size; k++)
			{
				for (int l = j - size; l <= j + size; l++)
				{
					if (!WorldGen.InWorld(k, l, 1) || !(Math.Abs(l - j) < Math.Sqrt(size * size + size * size)))
					{
						continue;
					}

					int tileType = Main.tile[k, l].type;

					if (TileID.Sets.Conversion.Grass[tileType])
					{
                        ConvertTile(k, l, (ushort)ModContent.TileType<Tiles.Biomes.Madness.MadGrass>());
					}
					else if (tileType == TileID.Dirt)
					{
						ConvertTile(k, l, (ushort)ModContent.TileType<Tiles.Biomes.Madness.MadDirt>());
					}
				}
			}
		}
	}
}
