using FFMod.Content.Projectiles.Sprays;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Ammo
{
    public sealed class MadSolution : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mad Solution");
            Tooltip.SetDefault("Used by the Clentaminator" + "\n" + "Spreads the Madness");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.consumable = true;

            Item.width = 12;
            Item.height = 14;

            Item.maxStack = 999;
			Item.rare = ItemRarityID.Orange;

			Item.ammo = AmmoID.Solution;
            Item.shoot = ModContent.ProjectileType<MadSpray>() - ProjectileID.PureSpray;
        }
    }
}
