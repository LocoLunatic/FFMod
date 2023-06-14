using FFMod.Content.NPCs.Critters;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Critters
{
    public class GoldStinkbugItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gold Stinkbug");
            // Tooltip.SetDefault("'It still stinks'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;

            Item.width = 36;
            Item.height = 36;
            Item.rare = ItemRarityID.Orange;
            Item.bait = 50;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.consumable = true;

            Item.value = Item.sellPrice(0, 10, 0, 0);
        }

        public override bool? UseItem(Player player)
        {
            int index = NPC.NewNPC(new EntitySource_SpawnNPC(), (int)(player.position.X + Main.rand.Next(-20, 20)), (int)(player.position.Y - 0f),
                ModContent.NPCType<GoldStinkbugNPC>());

            if (Main.netMode == NetmodeID.Server && index < Main.maxNPCs)
                NetMessage.SendData(MessageID.SyncNPC, number: index);

            return true;
        }
    }
}
