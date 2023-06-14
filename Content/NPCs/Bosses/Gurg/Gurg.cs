using AAMod.Common.Globals;
using FFMod.Content.Items.Critters;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.NPCs.Bosses.Gurg
{
    [AutoloadBossHead]
    public class Gurg : ModNPC
    {
        public enum ActionState
        {
            Start,
            Idle,
            Jump,
            Throw,
            Summon
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Zombie Goliath");
            NPCDebuffImmunityData debuffData = new()
            {
                SpecificallyImmuneTo = new int[]
                {
                    BuffID.Confused
                }
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);

            Main.npcFrameCount[Type] = 38;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 2360;
            NPC.damage = 24;
            NPC.defense = 10;

            NPC.width = 90;
            NPC.height = 90;

            NPC.aiStyle = 3;

            NPC.knockBackResist = 0f;

            NPC.value = Item.buyPrice(gold: 1);

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.boss = true;
            NPC.npcSlots = 10f;
            if (!Main.dedServ)
            {
                Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Gurg");
            }
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.6f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
               BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                new FlavorTextBestiaryInfoElement("A colossal zombie, tougher and meaner than his brethren, he uses his brute strength to wreak havoc wherever he goes. He calls himself 'Gurg'.")
            });
        }
        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref AABossDowned.downedGurg, -1);
        }

        public override void AI()
        {
            Player player = Main.player[NPC.target];

            if (NPC.target < 0 || NPC.target == 255 || player.dead || !player.active)
                NPC.TargetClosest();
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;
            if (++NPC.frameCounter > 4)
            {
                NPC.frame.Y += frameHeight;
                NPC.frameCounter = 0;
                if (NPC.frame.Y > 5 * frameHeight)
                    NPC.frame.Y = 0;
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, 0f, 0f, 100, default, 1.5f);
                }
            }
        }
    }
}