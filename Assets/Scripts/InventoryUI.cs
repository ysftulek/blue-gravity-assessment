using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	[SerializeField] InventorySlot[] _inventorySlots;

	Inventory _inventory;
	int _index;
	
	public void Show(ItemInfo[] item, Inventory inventory)
	{
		_inventory = inventory;
		
		for (int i = 0; i < item.Length; i++)
		{
			_inventorySlots[i].Initialize(this, item[i]);
		}
		
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void SellItem(ItemInfo itemInfo)
	{
		_inventory.SellItem(itemInfo);
	}
	
	void Reset()
	{
		_inventorySlots = GetComponentsInChildren<InventorySlot>();
	}
}