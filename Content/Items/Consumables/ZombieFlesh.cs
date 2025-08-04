using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Consumables
{
    public class ZombieFlesh : ModItem
    {
        public override void SetStaticDefaults()
        {

            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(209, 214, 138),
                new Color(41, 41, 37),
                new Color(129, 38, 41)
            };
            Item.ResearchUnlockCount = 20;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(copper: 6);

            Item.buffType = BuffID.Weak;
            Item.buffTime = 720;

            Item.healLife = 5;
        }
    }
}