using FFMod.Common.ID;
using FFMod.Common.Systems;
using Terraria;
using Terraria.ModLoader;

namespace FFMod.Content.Biomes.RedMush
{
    public sealed class MadnessSurfaceBiome : ModBiome
    {
        public override string BackgroundPath => AssetPathID.TexturesPath + "Map/MadnessMap";

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("FFMod/MadnessSurfaceBgStyle");

        public override void SetStaticDefaults() => DisplayName.SetDefault("Madness");

        public override bool IsBiomeActive(Player player) => (player.ZoneSkyHeight || player.ZoneOverworldHeight) && ModContent.GetInstance<TileCountSystem>().MadnessTileCount > 100;
    }
}