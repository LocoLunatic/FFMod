using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using AAMod.Common.Globals;
using FFMod.Content.NPCs.Bosses.Gurg;
using FFMod.Content.Items.BossSummons;

namespace FFMod.CrossMod
{
    internal class WeakReferences
    {
        public static void PerformModSupport()
        {
            PerformBossChecklistSupport();
        }
        private static void PerformBossChecklistSupport()
        {
            FFMod mod = FFMod.Instance;
            if (ModLoader.TryGetMod("BossChecklist", out Mod bossChecklist))
            {
                #region Gurg
                bossChecklist.Call("AddBoss", mod, "Zombie Goliath", ModContent.NPCType<Gurg>(), 1.4f, (Func<bool>)(() => AABossDowned.downedGurg), (Func<bool>)(() => true),
                    new List<int>
                    {

                    },
                    ModContent.ItemType<MegaBrain>(), "Use a [i:" + ModContent.ItemType<MegaBrain>() + "] at night.",
                    "The Zombie Goliath searches for something else to wreck...",
                    (SpriteBatch sb, Rectangle rect, Color color) => 
                    {
                        Texture2D texture = ModContent.Request<Texture2D>("FFMod/CrossMod/BossChecklist/Gurg").Value;
                        Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                        sb.Draw(texture, centered, color);
                    });
                #endregion

                /*KingSlime = 1f;
                EyeOfCthulhu = 2f;
                EaterOfWorlds = 3f; // and Brain of Cthulhu
                QueenBee = 4f;
                Skeletron = 5f;
                DeerClops = 6f;
                WallOfFlesh = 7f;
                QueenSlime = 8f;
                TheTwins = 9f;
                TheDestroyer = 10f;
                SkeletronPrime = 11f;
                Plantera = 12f;
                Golem = 13f;
                Betsy = 14f;
                EmpressOfLight = 15f;
                DukeFishron = 16f;
                LunaticCultist = 17f;
                Moonlord = 18f;*/
            }
        }
    }
}
