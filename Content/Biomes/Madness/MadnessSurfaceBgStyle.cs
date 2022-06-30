using FFMod.Common.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace FFMod.Content.Biomes.Madness
{
    public sealed class MadnessSurfaceBgStyle : ModSurfaceBackgroundStyle
	{
		public override void ModifyFarFades(float[] fades, float transitionSpeed)
		{
			for (int i = 0; i < fades.Length; i++)
			{
				if (i == Slot)
				{
					fades[i] += transitionSpeed;
				}
				else
				{
					fades[i] -= transitionSpeed;
				}

				fades[i] = MathHelper.Clamp(fades[i], 0f, 1f);
			}
		}

		public override int ChooseFarTexture() => BackgroundTextureLoader.GetBackgroundSlot(AssetPathID.TexturesPath + "Backgrounds/Madness/MadnessBackgroundFar");

		public override int ChooseMiddleTexture() => BackgroundTextureLoader.GetBackgroundSlot(AssetPathID.TexturesPath + "Backgrounds/Madness/MadnessBackgroundMiddle");

		public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b) => BackgroundTextureLoader.GetBackgroundSlot(AssetPathID.TexturesPath + "Backgrounds/Madness/MadnessBackgroundClose");
	}
}