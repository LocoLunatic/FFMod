using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Utilities.Extensions
{
    public static class NPCExtensions
    {
        public static void Kill(this NPC npc, bool hitEffect = true)
        {
            if (!NPCLoader.CheckDead(npc))
            {
                return;
            }

            if (hitEffect)
            {
                npc.HitEffect();
            }

            npc.checkDead();

            npc.life = 0;
            npc.active = false;
        }

        public static bool DrawNPCCentered(this NPC npc, SpriteBatch spriteBatch, Color color, Texture2D texture = null)
        {
            texture ??= TextureAssets.Npc[npc.type].Value;

            Vector2 origin = npc.frame.Size() / 2f + new Vector2(0f, npc.ModNPC.DrawOffsetY);

            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Vector2 drawPosition = npc.Center.ToDrawPosition() + new Vector2(0f, npc.gfxOffY);

            spriteBatch.Draw(texture, drawPosition, npc.frame, npc.GetAlpha(color), npc.rotation, origin, npc.scale, effects, 0f);

            return false;
        }

        public static bool DrawNPCAfterimageCentered(this NPC npc, SpriteBatch spriteBatch, Color color, Texture2D texture = null, float initialOpacity = 0.8f, float opacityDegrade = 0.2f, int stepSize = 1)
        {
            texture ??= TextureAssets.Npc[npc.type].Value;

            Vector2 origin = npc.frame.Size() / 2f;

            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            for (int i = 0; i < NPCID.Sets.TrailCacheLength[npc.type]; i += stepSize)
            {
                float opacity = initialOpacity - opacityDegrade * i / stepSize;

                Vector2 position = npc.oldPos[i].ToDrawPosition() + npc.Hitbox.Size() / 2f + new Vector2(0f, npc.gfxOffY);

                spriteBatch.Draw(texture, position, npc.frame, npc.GetAlpha(color) * opacity, npc.oldRot[i], origin, npc.scale, effects, 0f);
            }

            return false;
        }
    }
}