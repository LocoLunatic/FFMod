using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Weapons.Magic
{
    public class ElementalBlaster : ModItem
    {
        public override string Texture => FFMod.PlaceholderTexture;
        public override void SetDefaults()
        {
            Item.noMelee = true;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Magic;
            Item.damage = 20;
            Item.mana = 3;
            Item.knockBack = 3f;

            Item.width = 40;
            Item.height = 40;

            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.shootSpeed = 7f;
            Item.shoot = ModContent.ProjectileType<EBlaster_Proj>();

            Item.rare = ItemRarityID.Orange;

            Item.value = Item.sellPrice(silver: 10);
        }
        public int AttackMode;
        public override bool AltFunctionUse(Player player) => true;
        public override void ModifyManaCost(Player player, ref float reduce, ref float mult)
        {
            if (player.altFunctionUse == 2)
                mult *= 0;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                SoundEngine.PlaySound(SoundID.Item4 with { Volume = 0.5f, Pitch = -0.5f });
            }

            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                player.itemAnimationMax = 5;
                player.itemTime = 5;
                player.itemAnimation = 5;

                AttackMode++;
                if (AttackMode >= 3)
                    AttackMode = 0;

                switch (AttackMode)
                {
                    case 0:
                        Item.mana = 3;
                        Item.useAnimation = 30;
                        Item.useTime = 5;
                        Item.reuseDelay = 0;
                        Item.consumeAmmoOnLastShotOnly = true;
                        CombatText.NewText(player.getRect(), Color.OrangeRed, Language.GetTextValue("Burn"), true, false);
                        break;
                    case 1:
                        Item.mana = 5;
                        Item.useAnimation = 40;
                        Item.useTime = 40;
                        Item.reuseDelay = 0;
                        CombatText.NewText(player.getRect(), Color.Yellow, Language.GetTextValue("Shock"), true, false);
                        break;
                    case 2:
                        Item.mana = 5;
                        Item.useAnimation = 12;
                        Item.useTime = 4;
                        Item.reuseDelay = 14;
                        Item.consumeAmmoOnLastShotOnly = true;
                        CombatText.NewText(player.getRect(), Color.LightSkyBlue, Language.GetTextValue("Freeze"), true, false);
                        break;
                }
            }
            else
            {
                switch (AttackMode)
                {
                    case 0:

                        damage = (int)(damage * 0.5f);

                        Projectile.NewProjectile(source, position, velocity, ProjectileID.Flames, damage, knockback, player.whoAmI);
                        SoundEngine.PlaySound(SoundID.Item34, player.position);

                        break;
                    case 1:

                        float numberProjectiles = 4;
                        float rotation = MathHelper.ToRadians(30);

                        position += Vector2.Normalize(velocity) * 30f;

                        for (int i = 0; i < numberProjectiles; i++)
                        {
                            Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                            Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
                        }
                        SoundEngine.PlaySound(SoundID.Item157, player.position);
                        break;

                    case 2:

                        Projectile.NewProjectile(source, position, velocity, ProjectileID.Blizzard, damage, knockback, player.whoAmI);
                        SoundEngine.PlaySound(SoundID.Item51, player.position);
                        break;

                }
            }

            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0f, -5f);
        }

        public override void AddRecipes()
            => CreateRecipe()
            .AddIngredient(ItemID.Ruby, 5)
            .AddIngredient(ItemID.Topaz, 5)
            .AddIngredient(ItemID.Sapphire, 5)
            .AddIngredient(ItemID.SpaceGun)
            .AddTile(TileID.Anvils)
            .Register();
    }
    public class EBlaster_Proj : ModProjectile
    {
        public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.MartianTurretBolt;
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;

            Projectile.friendly = true;
            Projectile.tileCollide = true;

            Projectile.width = 16;
            Projectile.height = 20;

            Projectile.penetrate = 2;

            Projectile.timeLeft = 180;
            AIType = ProjectileID.MartianTurretBolt;
        }
        public override void AI()
        {
            Projectile.frameCounter++;

            if (Projectile.frameCounter >= 5)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }

            if (Projectile.frame > 3)
            {
                Projectile.frame = 0;
            }

            Projectile.rotation = Projectile.velocity.ToRotation();
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.localNPCImmunity[target.whoAmI] = 20;
            target.immune[Projectile.owner] = 10;

            Projectile.damage = (int)(Projectile.damage * 0.8);
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 7; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch, 0f, 0f);
                dust.scale = Main.rand.NextFloat(1f, 2f);
                dust.velocity *= 10f;
                dust.noGravity = true;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Asset<Texture2D> texture = TextureAssets.Projectile[Type];
            Rectangle rect = texture.Frame(1, 4, 0, Projectile.frame);
            Vector2 drawOrigin = rect.Size() / 2;
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(texture.Value, Projectile.Center + new Vector2(0, 2) - Main.screenPosition, rect, Projectile.GetAlpha(Color.LightYellow), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);

            return false;
        }
    } 
}
