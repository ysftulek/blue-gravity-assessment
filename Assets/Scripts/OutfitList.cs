using UnityEngine;

[CreateAssetMenu(fileName = "Outfit List", menuName = "Outfit List", order = 0)]
public class OutfitList : ScriptableObject
{
	[SerializeField] Sprite[] _outfits;

	public Sprite GetOutfit(int index)
	{
		return _outfits[index];
	}

	public int Count()
	{
		return _outfits.Length;
	}
}