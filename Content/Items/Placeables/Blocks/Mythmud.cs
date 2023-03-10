using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Placeables.Blocks
{
	public class Mythmud : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythmud");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

            Item.maxStack = 999;
            Item.width = Item.height = 16;

            Item.useTime = 10;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.createTile = ModContent.TileType<Tiles.Biomes.Mythos.Mythmud>();
        }
    }
}
