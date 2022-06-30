using System.Collections.Generic;
using Terraria.ModLoader;

namespace FFMod
{
	public class FFMod : Mod
	{
		private List<ILoadable> _loadCache;
		public const string Abbreviation = "FF";
		public const string AbbreviationPrefix = Abbreviation + ":";
		public const string InvisibleTexture = "FFMod/Assets/Textures/InvisibleTexture";
		public const string PlaceholderTexture = "FFMod/Assets/Textures/PlaceholderTexture";
	}
}