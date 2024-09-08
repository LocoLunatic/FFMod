using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AAMod.Common.Globals
{
    public class AABossDowned : ModSystem
    {
        public static bool downedGurg;

        public override void OnWorldLoad()
        {
            downedGurg = false;
        }

        public override void OnWorldUnload()
        {
            downedGurg = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();

            if (downedGurg)
                downed.Add("downedGurg");

            tag["downed"] = downed;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");

            downedGurg = downed.Contains("downedGurg");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();

            flags[0] = downedGurg;

            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();

            downedGurg = flags[3];
        }
    }
}
