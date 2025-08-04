using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Materials
{
    public class CrabCarapace : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 30;

            Item.maxStack = Item.CommonMaxStack;

            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(copper: 14);
        }
    }
}