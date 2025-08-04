using AAMod.Common.Globals;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
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
            Attacks,
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Zombie Goliath");
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new()
            {
                Position = new Vector2(0f, 90f),
                PortraitPositionYOverride = 60f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 2660;
            NPC.damage = 28;
            NPC.defense = 10;

            NPC.width = 74;
            NPC.height = 166;

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
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.FFMod.FlavorTextBestiary.Gurg"))
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

        public override void ModifyHitByProjectile(Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            if (projectile.type == ProjectileID.Grenade)
                modifiers.FinalDamage /= 2;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                for (int i = 0; i < 12; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, 0f, 0f, 100, default, 1.5f);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, 0f, 0f, 100, default, 1.5f);
            }
        }
    }
}