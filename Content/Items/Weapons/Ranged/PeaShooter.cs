using FFMod.Content.Projectiles.Ranged;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Weapons.Ranged
{
	public class PeaShooter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pea Shooter");
            Tooltip.SetDefault("'Great for deterring zombies on your lawn!'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
			Item.width = 68;
			Item.height = 36;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Blue;

			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;

			Item.UseSound = SoundID.Item61;

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 20;
			Item.knockBack = 5f;
			Item.noMelee = true;

			Item.shoot = ModContent.ProjectileType<Pea>();
			Item.shootSpeed = 12f;
		}
    }
}
