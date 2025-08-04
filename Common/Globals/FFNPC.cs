using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Common.Globals.NPCs
{
    class FFNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool fireEnemy;

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Zombie)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Consumables.ZombieFlesh>(), 2));

            if (npc.type == NPCID.Crab)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Materials.CrabCarapace>(), 2));
        }

        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            if (npc.type is NPCID.BlazingWheel or NPCID.FireImp or NPCID.Demon or NPCID.VoodooDemon or NPCID.Hellbat or NPCID.LavaSlime or NPCID.MeteorHead or NPCID.BurningSphere or NPCID.HellArmoredBones or NPCID.HellArmoredBonesMace
                or NPCID.HellArmoredBonesSpikeShield or NPCID.HellArmoredBonesSword or NPCID.HoppinJack or NPCID.Lavabat or NPCID.RedDevil or NPCID.RuneWizard or NPCID.SolarCorite or NPCID.SolarCrawltipedeTail or NPCID.SolarCrawltipedeHead
                or NPCID.SolarCrawltipedeBody or NPCID.SolarDrakomire or NPCID.SolarDrakomireRider or NPCID.SolarFlare or NPCID.SolarSolenian or NPCID.SolarSpearman or NPCID.SolarSroller or NPCID.DD2Betsy) 
            {
                fireEnemy = true;
            }
            
            base.OnSpawn(npc, source);
        }
    }
}
