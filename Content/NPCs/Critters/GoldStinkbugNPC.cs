using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.NPCs.Critters
{
    public sealed class GoldStinkbugNPC : ModNPC
    {
        private int currentFrame;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Stinkbug");

            Main.npcFrameCount[Type] = 8;

            NPCID.Sets.CountsAsCritter[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.knockBackResist = 0.5f;

            NPC.lifeMax = 10;

            NPC.width = 10;
            NPC.height = 10;

            NPC.aiStyle = NPCAIStyleID.Ladybug;
            AIType = NPCID.LadyBug;

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(5))
            {
                Vector2 direction = new(Main.rand.Next(-10, 11), Main.rand.Next(-10, 11));
                direction.Normalize();
                direction.X *= 0.66f;
                direction.Y = Math.Abs(direction.Y);

                Vector2 velocity = direction * Main.rand.Next(3, 5) * 0.25f;

                Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Gold, velocity.X, velocity.Y * 0.5f, 100, default, 0.7f);
                dust.velocity *= 0.1f;
                dust.velocity.Y -= 0.5f;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;

            NPC.frameCounter++;

            if (NPC.frameCounter > 5f)
            {
                currentFrame++;
            }

            if (NPC.velocity.Y != 0f)
            {
                if (currentFrame > 7)
                {
                    currentFrame = 4;
                }
            }
            else if (NPC.velocity.X != 0f)
            {
                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }
            }

            NPC.frame.Y = currentFrame * frameHeight;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Gold, 0f, 0f, 100, default, 1.5f);
                }
            }
        }
    }
}