using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace FFMod.Utilities.Extensions
{
    public static class ProjectileExtensions
    {
        public static bool DrawProjectileCentered(this Projectile projectile, SpriteBatch spriteBatch, Color drawColor, Texture2D texture = null)
        {
            texture ??= TextureAssets.Projectile[projectile.type].Value;

            Rectangle frame = texture.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);

            Vector2 origin = frame.Size() / 2f + new Vector2(projectile.ModProjectile.DrawOriginOffsetX, projectile.ModProjectile.DrawOriginOffsetY);

            SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Vector2 drawPosition = projectile.Center.ToDrawPosition() + new Vector2(projectile.ModProjectile.DrawOffsetX, projectile.gfxOffY);

            spriteBatch.Draw(texture, drawPosition, frame, drawColor, projectile.rotation, origin, projectile.scale, effects, 0f);

            return false;
        }

        public static bool DrawProjectileAfterimageCentered(this Projectile projectile, SpriteBatch spriteBatch, Color drawColor, float initialOpacity = 0.8f, float opacityDegrade = 0.2f, int stepSize = 1, Texture2D texture = null)
        {
            texture ??= TextureAssets.Projectile[projectile.type].Value;

            Rectangle frame = texture.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);

            Vector2 origin = frame.Size() / 2f + new Vector2(projectile.ModProjectile.DrawOriginOffsetX, projectile.ModProjectile.DrawOriginOffsetY);

            SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[projectile.type]; i += stepSize)
            {
                float opacity = initialOpacity - opacityDegrade * i / stepSize;

                Vector2 position = projectile.oldPos[i].ToDrawPosition() + projectile.Hitbox.Size() / 2f + new Vector2(0f, projectile.gfxOffY);

                spriteBatch.Draw(texture, position, frame, drawColor * opacity, projectile.oldRot[i], origin, projectile.scale, effects, 0f);
            }

            return false;
        }
    }
}