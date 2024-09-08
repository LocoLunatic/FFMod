using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FFMod.Content.Items.Consumables
{
    public class ZombieFlesh : ModItem
    {
        public override string Texture => FFMod.PlaceholderTexture;
        public override void SetStaticDefaults()
        {

            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(237, 215, 80),
                new Color(233, 173, 41),
                new Color(222, 139, 38)
            };
            Item.ResearchUnlockCount = 20;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 28;
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