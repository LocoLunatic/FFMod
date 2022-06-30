using FFMod.Common.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace FFMod.Content.Biomes.RedMush
{
    public class MadnessSurfaceBiome : ModBiome
    {
        public override void SetStaticDefaults() 
            => DisplayName.SetDefault("Madness");

        public override SceneEffectPriority Priority 
            => SceneEffectPriority.BiomeHigh;

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle 
            => ModContent.Find<ModSurfaceBackgroundStyle>("FFMod/MadnessSurfaceBgStyle");

        public override string BackgroundPath => "Assets/Textures/Map/MadnessMap";
        public override Color? BackgroundColor => base.BackgroundColor;

        public override bool IsBiomeActive(Player player)
        {
            return (player.ZoneSkyHeight || player.ZoneOverworldHeight) && ModContent.GetInstance<TileCountSystem>().MadnessTileCount > 100;
        }
    }
}