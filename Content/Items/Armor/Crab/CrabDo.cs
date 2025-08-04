using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Armor.Crab
{
    [AutoloadEquip(EquipType.Body)]
    public class CrabDo : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;

            Item.defense = 7;

            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 12);
        }

        public override void AddRecipes()
        => CreateRecipe()
        .AddIngredient(ModContent.ItemType<Materials.CrabCarapace>(), 12)
        .AddIngredient(ItemID.Bone, 6)
        .AddTile(TileID.Anvils)
        .Register();
    }
}
