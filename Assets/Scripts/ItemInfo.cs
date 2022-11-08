using System;
using BlueGravity.Save_System;

namespace BlueGravity
{
	[Serializable]
	public struct ItemInfo
	{
		public SaveableRuntimeIntVariable Item;
		public SpritePricePair SpritePricePair;
	}
}