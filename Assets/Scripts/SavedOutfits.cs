using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Save Data", fileName = "Save Data", order = 0)]
public class SavedOutfits : ScriptableObject
{
	public List<int> ObtainedHatIndexes;
	public List<int> ObtainedBodyIndexes;
}