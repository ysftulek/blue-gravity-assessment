using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	[SerializeField] InventorySlot[] _inventorySlots;

	int _index;
	
	public void Show(List<ItemInfo> itemInfo)
	{
		for (int i = 0; i < itemInfo.Count; i++)
		{
			_inventorySlots[i].Initialize(itemInfo[i]);
		}
		
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	void Reset()
	{
		_inventorySlots = GetComponentsInChildren<InventorySlot>();
	}
}