using FFMod.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Armor.Crab
{
    [AutoloadEquip(EquipType.Legs)]
    public class CrabKegutsu : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;

            Item.defense = 5;

            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 8);
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage<SentinalClass>() += 0.1f;
        }
        public override void AddRecipes()
        => CreateRecipe()
        .AddIngredient(ModContent.ItemType<Materials.CrabCarapace>(), 8)
        .AddIngredient(ItemID.Bone, 4)
        .AddTile(TileID.Anvils)
        .Register();
    }
}
