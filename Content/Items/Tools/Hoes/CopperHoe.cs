using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Tools.Hoes
{
    public class CopperHoe : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.autoReuse = true;
            Item.useTurn = true;

            Item.width = 22;
            Item.height = 18;

            Item.damage = 3;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 30;
            Item.useTime = 26;
            Item.placeStyle = 0;

            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(0, 0, 3, 0);
        }
        //public override bool? UseItem(Player player)
        //{
            //if (Main.netMode == NetmodeID.Server)
                //return false;

            //Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
            //if (tile.HasTile && tile.TileType == TileID.Dirt && player.WithinPlacementRange(Player.tileTargetX, Player.tileTargetY))
            //{
            //    WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, ModContent.TileType<FarmLand>(), forced: true);
            //}
            //return true;
        //}

        public override void AddRecipes()
        => CreateRecipe()
        .AddIngredient(ItemID.CopperBar, 6)
        .AddRecipeGroup("Wood", 4)
        .AddTile(TileID.Anvils)
        .Register();
    }
}
