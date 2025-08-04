using FFMod.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FFMod.Content.NPCs.Enemies.Haven
{
    public class Mothboy : ModNPC
    {

        public override void SetDefaults()
        {
            NPC.lifeMax = 40;

            NPC.damage = 20;
            NPC.defense = 1;

            NPC.width = 40;
            NPC.height = 60;

            NPC.aiStyle = 0;

            NPC.value = Item.buyPrice(0, 0, 2, 0);

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.FFMod.FlavorTextBestiary.Mothboy"))
            });
        }
        public override void AI()
        {
            Player player = Main.player[NPC.target];

            NPC.TargetClosest();

            if (NPC.Sight(player, 200, false, true)) 
            {
                NPC.Transform(ModContent.NPCType<Mothboy_Fly>());
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            int amount = NPC.life <= 0 ? 20 : 2;

            for (int i = 0; i < amount; i++)
            {
                Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.Blood, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
                dust.velocity *= 0.8f;
            }

            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("FFMod/MothboyGore" + (i + 1)).Type, 1);
                }
            }

            NPC.Transform(ModContent.NPCType<Mothboy_Fly>());
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, NPC.Center - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            spriteBatch.Draw(texture, NPC.Center - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);

            return false;
        }

        //public override float SpawnChance(NPCSpawnInfo spawnInfo)
        //{
        //float baseChance = SpawnCondition.OverworldDay.Chance;
        //float multiplier = Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == TileID.Grass ? 0.25f : 0f;

        //return baseChance * multiplier;
        //}

    }
    public class Mothboy_Fly : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new() { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }
        public override void SetDefaults()
        {
            NPC.lifeMax = 40;

            NPC.damage = 20;
            NPC.defense = 1;

            NPC.width = 40;
            NPC.height = 60;

            NPC.aiStyle = 14;

            NPC.value = Item.buyPrice(0, 0, 2, 0);

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        private int frame;
        public override void FindFrame(int frameHeight)
        {
            NPC.rotation = NPC.velocity.X * 0.04f;

            NPC.frameCounter++;

            if (NPC.frameCounter >= 5f)
            {
                frame++;
                NPC.frameCounter = 0f;
            }

            if (frame > 3)
                frame = 0;

            NPC.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            Player player = Main.player[NPC.target];

            NPC.TargetClosest();
            NPC.LookByVelocity();

        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            int amount = NPC.life <= 0 ? 20 : 2;

            for (int i = 0; i < amount; i++)
            {
                Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.Blood, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
                dust.velocity *= 0.8f;
            }

            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("FFMod/MothboyGore" + (i + 1)).Type, 1);
                }
            }
        }

        public override void OnKill()
        {
            NPC nPC = new();
            nPC.SetDefaults(ModContent.NPCType<Mothboy>());
            Main.BestiaryTracker.Kills.RegisterKill(nPC);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, NPC.Center - screenPos, NPC.frame, NPC.GetNPCColorTintedByBuffs(drawColor), NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            spriteBatch.Draw(texture, NPC.Center - screenPos, NPC.frame, NPC.GetNPCColorTintedByBuffs(Color.White), NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);

            return false;
        }
    }
}
