using FFMod.CrossMod;
using Terraria.ModLoader;

namespace FFMod
{
    public class FFMod : Mod 
    {
        public const string InvisibleTexture = "FFMod/Assets/Textures/InvisibleTexture";
        public const string PlaceholderTexture = "FFMod/Assets/Textures/PlaceholderTexture";

        public override void PostSetupContent()
        {
            WeakReferences.PerformModSupport();
        }
        public static FFMod Instance => ModContent.GetInstance<FFMod>();
    }
}