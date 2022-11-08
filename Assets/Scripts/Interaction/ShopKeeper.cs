using System;
using BlueGravity.Save_System;
using DG.Tweening;
using UnityEngine;

namespace BlueGravity.Interaction
{
	public class ShopKeeper : MonoBehaviour, IInteractable
	{
		[SerializeField] GameObject _shopPanelRoot;
		[SerializeField] Transform _scalableShopPanel;
		[SerializeField] ShopOutfitSlot _hatSlot;
		[SerializeField] ShopOutfitSlot _bodySlot;
		[SerializeField] Camera _outfitCam;
		[SerializeField] SaveableRuntimeIntVariable _money;

		Inventory _inventory;
		Action _interactionEnded;

		void OnEnable()
		{
			_hatSlot.ItemUpdated += HatSlotOnItemUpdated;
			_bodySlot.ItemUpdated += BodySlotOnItemUpdated;
			_hatSlot.ItemBought += HatSlotOnItemBought;
			_bodySlot.ItemBought += BodySlotOnItemBought;
		}
	
		void OnDisable()
		{
			_hatSlot.ItemUpdated -= HatSlotOnItemUpdated;
			_bodySlot.ItemUpdated -= BodySlotOnItemUpdated;
			_hatSlot.ItemBought -= HatSlotOnItemBought;
			_bodySlot.ItemBought -= BodySlotOnItemBought;
		}

		public void Interact(Interactor interactor, Action interactionEndedCallback)
		{
			_interactionEnded = interactionEndedCallback;
			_shopPanelRoot.SetActive(true);
			_scalableShopPanel.DOComplete();
			_scalableShopPanel.localScale = Vector3.one * float.Epsilon;
			_scalableShopPanel.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
			_outfitCam.transform.position = interactor.transform.position + Vector3.back * 10f + Vector3.up * 0.5f;
		
			if (interactor.TryGetComponent(out Inventory inventory))
			{
				_inventory = inventory;
				_hatSlot.Initialize();
				_bodySlot.Initialize();
			}
		}

		public void HideShop()
		{
			_shopPanelRoot.SetActive(false);
			SetInteractorOutfit(_hatSlot, _inventory.Hat);
			SetInteractorOutfit(_bodySlot, _inventory.Body);
			_interactionEnded?.Invoke();
			_interactionEnded = null;
		}

		void SetInteractorOutfit(ShopOutfitSlot shopOutfitSlot, Outfit outfit)
		{
			if (shopOutfitSlot.GetSelectedItem.Item.RuntimeValue == 1)
			{
				outfit.SetOutfit(shopOutfitSlot.GetSelectedItem);
			}
			else
			{
				outfit.ResetOutfit();
			}
		}
	
		void TryBuyItem(ItemInfo itemInfo)
		{
			if (_money.RuntimeValue >= itemInfo.SpritePricePair.Price)
			{
				itemInfo.Item.RuntimeValue = 1;
				_money.RuntimeValue -= itemInfo.SpritePricePair.Price;
			}
		}

		void BodySlotOnItemBought(ItemInfo itemInfo)
		{
			TryBuyItem(itemInfo);
		}
	
		void HatSlotOnItemBought(ItemInfo itemInfo)
		{
			TryBuyItem(itemInfo);
		}

		void HatSlotOnItemUpdated(Sprite obj)
		{
			_inventory.Hat.PreviewOutfit(obj);
		}
	
		void BodySlotOnItemUpdated(Sprite obj)
		{
			_inventory.Body.PreviewOutfit(obj);
		}
	}
}