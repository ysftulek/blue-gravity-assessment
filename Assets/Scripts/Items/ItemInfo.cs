using System;
using BlueGravity.Save_System;

namespace BlueGravity.Items
{
	[Serializable]
	public struct ItemInfo
	{
		public SaveableRuntimeIntVariable Item;
		public SpritePricePair SpritePricePair;
	}
}