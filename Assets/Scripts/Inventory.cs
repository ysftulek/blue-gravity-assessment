using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] OutfitList _hatList;
	[SerializeField] OutfitList _bodyList;
	[SerializeField] InventoryUI _inventoryUI;
	
	public SavedOutfits SavedOutfits;
	public Outfit Hat;
	public Outfit Body;

	void Awake()
	{
		Hat.Initialize();
		Body.Initialize();
	}
	
	public void ResetAll()
	{
		Hat.ResetOutfit();
		Body.ResetOutfit();
	}
}