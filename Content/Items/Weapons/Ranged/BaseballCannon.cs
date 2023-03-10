using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using FFMod.Content.Projectiles.Ranged;
using Terraria.DataStructures;
using Terraria;

namespace FFMod.Content.Items.Weapons.Ranged
{
    public class BaseballCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Baseball Cannon");
			Tooltip.SetDefault("'Baseball stars would not recommend'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.width = 58;
			Item.height = 34;
			Item.rare = ItemRarityID.Blue;

			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;

			Item.UseSound = SoundID.Item61;
			Item.value = Item.sellPrice(0, 0, 8, 0);

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 6;
			Item.knockBack = 3;
			Item.noMelee = true;

			Item.shoot = ModContent.ProjectileType<Baseball>();
			Item.shootSpeed = 12f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8));
        }
    }
}
