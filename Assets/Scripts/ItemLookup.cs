using System;
using System.Collections.Generic;
using UnityEngine;

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

	public ItemInfo[] GetItemInfos(List<SaveableRuntimeIntVariable> items)
	{
		ItemInfo[] infos = new ItemInfo[items.Count];
		for (int i = 0; i < items.Count; i++)
		{
			SaveableRuntimeIntVariable saveableRuntimeIntVariable = items[i];
			infos[i].Item = saveableRuntimeIntVariable;
			infos[i].SpritePricePair = Lookup[saveableRuntimeIntVariable];
		}

		return infos;
	}
}