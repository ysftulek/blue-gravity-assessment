using System.Collections.Generic;
using UnityEngine;

namespace BlueGravity.Items
{
	public class InventoryUI : MonoBehaviour
	{
		[SerializeField] InventorySlot[] _inventorySlots;

		Inventory _inventory;
		int _index;
	
		public void Show(List<ItemInfo> item, Inventory inventory)
		{
			_inventory = inventory;
		
			for (int i = 0; i < item.Count; i++)
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
}