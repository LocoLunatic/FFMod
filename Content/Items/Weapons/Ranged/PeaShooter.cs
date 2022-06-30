using FFMod.Content.Projectiles.Ranged;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Weapons.Ranged
{
    public sealed class PeaShooter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pea Shooter");
            Tooltip.SetDefault("'Great for deterring zombies on your lawn!'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
			Item.noMelee = true;
			Item.autoReuse = true;

			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;

			Item.width = 68;
			Item.height = 36;

			Item.knockBack = 5f;

			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = SoundID.Item61;

			Item.shoot = ModContent.ProjectileType<Pea>();
			Item.shootSpeed = 12f;

			Item.rare = ItemRarityID.Blue;
		}            
	}
}