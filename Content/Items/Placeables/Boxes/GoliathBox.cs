using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Placeables.Boxes
{
	public class GoliathBox : ModItem
	{
		public override void SetStaticDefaults()
		{
            // DisplayName.SetDefault("Music Box (Zombie Goliath)");
            // Tooltip.SetDefault("MaestroVGM - Rotten Brawl");
            ItemID.Sets.CanGetPrefixes[Type] = false;
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox;
            Item.ResearchUnlockCount = 1;

			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Gurg"), ModContent.ItemType<GoliathBox>(), ModContent.TileType<Tiles.Boxes.GoliathBox>());
		}

		public override void SetDefaults()
		{
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.accessory = true;
			Item.hasVanityEffects = true;

			Item.width = 32;
			Item.height = 20;

			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;

			Item.createTile = ModContent.TileType<Tiles.Boxes.GoliathBox>();

			Item.rare = ItemRarityID.LightRed;
		}
	}
}
