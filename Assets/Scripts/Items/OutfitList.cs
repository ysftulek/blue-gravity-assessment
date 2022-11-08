using BlueGravity.Save_System;
using UnityEngine;

namespace BlueGravity.Items
{
	[CreateAssetMenu(fileName = "Outfit List", menuName = "Outfit List", order = 0)]
	public class OutfitList : ScriptableObject
	{
		[SerializeField] ItemInfo[] _outfits;

		public ItemInfo[] Outfits => _outfits;
	
		public SpritePricePair GetOutfitInfo(int index)
		{
			return _outfits[index].SpritePricePair;
		}

		public SaveableRuntimeIntVariable GetItem(int index)
		{
			return _outfits[index].Item;
		}

		public ItemInfo GetItemInfo(int i)
		{
			return _outfits[i];
		}
	
		public int Count => _outfits.Length;
	}
}