using System.Collections.Generic;
using BlueGravity.Save_System;
using UnityEngine;

namespace BlueGravity
{
	[CreateAssetMenu(fileName = "Item Lookup", menuName = "Item Lookup", order = 0)]
	public class ItemLookup : ScriptableObject
	{
		[SerializeField] OutfitList[] _outfitLists;

		public Dictionary<SaveableRuntimeIntVariable, SpritePricePair> Lookup;

		void OnEnable()
		{
			Lookup = new Dictionary<SaveableRuntimeIntVariable, SpritePricePair>();

			foreach (OutfitList itemInfo in _outfitLists)
			{
				foreach (ItemInfo outfit in itemInfo.Outfits)
				{
					Lookup.Add(outfit.Item, outfit.SpritePricePair);
				}
			}
		}

		public List<ItemInfo> GetAllOwnedItems()
		{
			List<ItemInfo> infos = new List<ItemInfo>();

			foreach (OutfitList outfitList in _outfitLists)
			{
				foreach (ItemInfo outfits in outfitList.Outfits)
				{
					if (outfits.Item.RuntimeValue == 1)
					{
						infos.Add(outfits);
					}
				}
			}

			return infos;
		}
	}
}