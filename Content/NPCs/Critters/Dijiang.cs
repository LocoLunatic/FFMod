using FFMod.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FFMod.Content.NPCs.Critters
{
    public class Dijiang : ModNPC
    {
        public enum ActionState
        {
            Idle,
            Wander
        }
        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }
        public ref float AITimer => ref NPC.ai[1];

        public ref float TimerRand => ref NPC.ai[2];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6;

            NPCID.Sets.CountsAsCritter[Type] = true;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 5;

            NPC.width = 36;
            NPC.height = 32;

            NPC.aiStyle = -1;

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.AAMod.FlavorTextBestiary.Dijiang"))
            });
        }
        private int frame;
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;

            if (NPC.frameCounter >= 8f)
            {
                frame++;
                NPC.frameCounter = 0f;
            }

            if (AIState == ActionState.Idle)
                frame = 0;

            if (frame > 5)
                frame = 0;

            NPC.frame.Y = frame * frameHeight;
        }

        bool hopped;
        public Vector2 moveTo;

        public override void OnSpawn(IEntitySource source)
        {
            TimerRand = Main.rand.Next(80, 180);
        }
        public override void AI()
        {
            Player player = Main.player[NPC.target];

            NPC.TargetClosest();
            NPC.LookByVelocity();

            switch (AIState)
            {
                case ActionState.Idle:

                    if (NPC.velocity.Y == 0)
                        NPC.velocity.X *= 0.5f;

                    AITimer++;

                    if (AITimer >= TimerRand)
                    {
                        moveTo = NPC.FindGround(15).ToWorldCoordinates();
                        AITimer = 0;
                        TimerRand = Main.rand.Next(120, 260);
                        AIState = ActionState.Wander;
                    }
                    break;

                case ActionState.Wander:

                    AITimer++;

                    if (AITimer >= TimerRand || NPC.Center.X + 20 > moveTo.X * 16 && NPC.Center.X - 20 < moveTo.X * 16)
                    {
                        AITimer = 0;
                        TimerRand = Main.rand.Next(120, 260);
                        AIState = ActionState.Idle;
                    }

                    float WalkAccel = 0.05f;
                    float WalkMaxVel = 1.0f;

                    if (NPC.Center.X > moveTo.X)
                    {
                        NPC.velocity.X -= WalkAccel;
                        if (NPC.velocity.X > 0f)
                            NPC.velocity.X -= WalkAccel;

                        if (NPC.velocity.X < 0f - WalkMaxVel)
                            NPC.velocity.X = 0f - WalkMaxVel;
                    }

                    if (NPC.Center.X < moveTo.X)
                    {
                        NPC.velocity.X += WalkAccel;
                        if (NPC.velocity.X < 0f)
                            NPC.velocity.X += WalkAccel;

                        if (NPC.velocity.X > WalkMaxVel)
                            NPC.velocity.X = WalkMaxVel;
                    }
                    break;

                default:
                    AIState = ActionState.Idle;
                    break;
            }

            BaseAI.WalkupHalfBricks(NPC);
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            int amount = NPC.life <= 0 ? 20 : 2;

            for (int i = 0; i < amount; i++)
            {
                Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.Blood, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
                dust.velocity *= 0.8f;
            }
        }

        //public override float SpawnChance(NPCSpawnInfo spawnInfo)
        //{
        //float baseChance = SpawnCondition.OverworldDay.Chance;
        //float multiplier = Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == TileID.Grass ? 0.25f : 0f;

        //return baseChance * multiplier;
        //}

    }
}
