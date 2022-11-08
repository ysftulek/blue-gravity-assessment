using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Save Data", fileName = "Save Data", order = 0)]
public class SavedOutfits : ScriptableObject
{
	[SerializeField] List<int> _outfitIndexes;

	public List<int> GetSavedIndexes => _outfitIndexes;
	public int Count => _outfitIndexes.Count;
	
	public event Action<int> SavedAdded;

	public int GetOutfitIndex(int index)
	{
		return _outfitIndexes[index];
	}
	
	public void AddOutfit(int index)
	{
		_outfitIndexes.Add(index);
		SavedAdded?.Invoke(index);
	}
}