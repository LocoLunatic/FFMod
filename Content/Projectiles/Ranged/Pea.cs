using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Projectiles.Ranged
{
    public sealed class Pea : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Pea");

        public override void SetDefaults()
        {
            Projectile.friendly = true;

            Projectile.DamageType = DamageClass.Ranged;

            Projectile.timeLeft = 300;
            Projectile.aiStyle = 0;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.NPCDeath1, Projectile.position);
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

            return true;
        }
    }
}