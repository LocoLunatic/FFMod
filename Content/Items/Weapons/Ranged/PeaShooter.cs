using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using FFMod.Content.Projectiles.Ranged;
using Terraria.DataStructures;
using Terraria;

namespace FFMod.Content.Items.Weapons.Ranged
{
    public class PeaShooter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pea Shooter");
			Tooltip.SetDefault("Fires high-velocity peas that deal splash damage"
				+ "\nDirect hits will always crit");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.width = 50;
			Item.height = 34;
			Item.rare = ItemRarityID.Blue;

			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;

			Item.UseSound = SoundID.Item61;
			Item.value = Item.sellPrice(0, 0, 8, 0);

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 12;
			Item.knockBack = 3;
			Item.noMelee = true;

			Item.shoot = ModContent.ProjectileType<Pea>();
			Item.shootSpeed = 16f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}
	}
}
