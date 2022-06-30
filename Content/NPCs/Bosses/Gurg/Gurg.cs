using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.NPCs.Bosses.Gurg
{
    [AutoloadBossHead]
    public sealed class Gurg : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gurg the Goliath");

            NPCID.Sets.BossBestiaryPriority.Add(Type);
            NPCID.Sets.DebuffImmunitySets.Add(Type, new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[]
                {
                    BuffID.Confused
                }
            });
        }

        public override void SetDefaults()
        {
            NPC.boss = true;
            NPC.lavaImmune = true;
            
            NPC.lifeMax = 1200;
            NPC.defense = 4;
            NPC.damage = 30;
            
            NPC.width = 46;
            NPC.height = 202;

            NPC.npcSlots = 10f;
            NPC.knockBackResist = 0f;   
            
            NPC.aiStyle = NPCAIStyleID.Fighter;
            AIType = NPCID.Zombie;

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            Music = MusicID.Boss1;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("A very large lad.")
            });
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.5f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.8f);
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 2f;
            return null;
        }
        
        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            damage *= 0.2;
            return true;
        }
        
        public override void FindFrame(int frameHeight) => NPC.spriteDirection = NPC.direction;
    }
}
