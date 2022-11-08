using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] OutfitList _hatList;
	[SerializeField] OutfitList _bodyList;
	[SerializeField] InventoryUI _inventoryUI;
	[SerializeField] InputChannel _inputChannel;
	
	public SavedOutfits SavedHats;
	public SavedOutfits SavedBodies;
	public Outfit Hat;
	public Outfit Body;

	List<ItemInfo> _itemInfos;
	bool _inventoryToggle;

	void Awake()
	{
		Hat.SetupDefaultSprite();
		Body.SetupDefaultSprite();

		PullSavedOutfits();
	}

	void OnEnable()
	{
		_inputChannel.InventoryToggled += InputChannelOnInventoryToggled;
		SavedHats.SavedAdded += SavedHatsOnSavedAdded;
		SavedBodies.SavedAdded += SavedBodiesOnSavedAdded;
	}

	void OnDisable()
	{
		_inputChannel.InventoryToggled -= InputChannelOnInventoryToggled;
		SavedHats.SavedAdded -= SavedHatsOnSavedAdded;
		SavedBodies.SavedAdded -= SavedBodiesOnSavedAdded;
	}

	public void ResetAll()
	{
		Hat.ResetOutfit();
		Body.ResetOutfit();
	}

	void PullSavedOutfits()
	{
		_itemInfos = new List<ItemInfo>();
		
		for (int i = 0; i < SavedHats.Count; i++)
		{
			AddItem(SavedHats.GetOutfitIndex(i), _hatList);
		}

		for (int i = 0; i < SavedBodies.Count; i++)
		{
			AddItem(SavedBodies.GetOutfitIndex(i), _bodyList);
		}
	}
	
	void SavedBodiesOnSavedAdded(int obj)
	{
		AddItem(obj, _bodyList);
	}

	void SavedHatsOnSavedAdded(int obj)
	{
		AddItem(obj, _hatList);
	}
	
	void InputChannelOnInventoryToggled()
	{
		_inventoryToggle = !_inventoryToggle;
		if (_inventoryToggle)
		{
			_inventoryUI.Show(_itemInfos);
		}
		else
		{
			_inventoryUI.Hide();
		}
	}

	void AddItem(int index, OutfitList outfitList)
	{
		ItemInfo info = new ItemInfo();
		info.ItemList = outfitList;
		info.ItemIndex = index;
		_itemInfos.Add(info);
	}
}