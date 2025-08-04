using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Armor.Crab
{
    [AutoloadEquip(EquipType.Head)]
    public class CrabKabuto : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 26;

            Item.defense = 6;

            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 10);
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<CrabDo>() && legs.type == ModContent.ItemType<CrabKegutsu>();

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased movement speed in water";

            if (player.wet)
                player.moveSpeed *= 1.25f;
        }

        public override void AddRecipes()
        => CreateRecipe()
        .AddIngredient(ModContent.ItemType<Materials.CrabCarapace>(), 10)
        .AddIngredient(ItemID.Bone, 5)
        .AddTile(TileID.Anvils)
        .Register();
    }
}
