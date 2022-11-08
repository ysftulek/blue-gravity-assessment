using System.Collections.Generic;
using BlueGravity.Save_System;
using UnityEngine;
namespace BlueGravity
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField] OutfitList _hatList;
		[SerializeField] OutfitList _bodyList;
		[SerializeField] InventoryUI _inventoryUI;
		[SerializeField] InputChannel _inputChannel;
		[SerializeField] ItemLookup _itemLookup;
		[SerializeField] SaveableRuntimeIntVariable _money;
	
		public Outfit Hat;
		public Outfit Body;

		List<SaveableRuntimeIntVariable> _ownedItems;
		bool _inventoryToggle;

		void Start()
		{
			Hat.SetupDefaultSprite();
			Body.SetupDefaultSprite();

			PullSavedOutfits();
		}

		void OnEnable()
		{
			_inputChannel.InventoryToggled += InputChannelOnInventoryToggled;
		}

		void OnDisable()
		{
			_inputChannel.InventoryToggled -= InputChannelOnInventoryToggled;
		}

		public void SellItem(ItemInfo itemInfo)
		{
			_money.RuntimeValue += itemInfo.SpritePricePair.Price;
			itemInfo.Item.RuntimeValue = 0;
			_ownedItems.Remove(itemInfo.Item);
		}

		void PullSavedOutfits()
		{
			_ownedItems = new List<SaveableRuntimeIntVariable>();
		
			for (int i = 0; i < _hatList.Count; i++)
			{
				AddItem(_hatList.GetItem(i));
			}

			for (int i = 0; i < _bodyList.Count; i++)
			{
				AddItem(_bodyList.GetItem(i));
			}
		}

		void InputChannelOnInventoryToggled()
		{
			_inventoryToggle = !_inventoryToggle;
			if (_inventoryToggle)
			{
				List<ItemInfo> itemInfos = _itemLookup.GetAllOwnedItems();
				_inventoryUI.Show(itemInfos, this);
			}
			else
			{
				_inventoryUI.Hide();
			}
		}

		void AddItem(SaveableRuntimeIntVariable item)
		{
			if (item.RuntimeValue == 1)
			{
				_ownedItems.Add(item);
			}
		}
	}
}