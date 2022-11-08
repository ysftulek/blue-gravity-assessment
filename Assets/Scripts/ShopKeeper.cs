using System;
using DG.Tweening;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
	[SerializeField] GameObject _shopPanelRoot;
	[SerializeField] Transform _scalableShopPanel;
	[SerializeField] ShopOutfitSlot _hatSlot;
	[SerializeField] ShopOutfitSlot _bodySlot;
	[SerializeField] Camera _outfitCam;
	[SerializeField] SavedOutfits _savedHats;
	[SerializeField] SavedOutfits _savedBodies;
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
			_hatSlot.Initialize(inventory.Hat.WornOutfitIndex, inventory.SavedHats.GetSavedIndexes);
			_bodySlot.Initialize(inventory.Body.WornOutfitIndex, inventory.SavedBodies.GetSavedIndexes);
		}
	}

	public void HideShop()
	{
		_shopPanelRoot.SetActive(false);
		_inventory.ResetAll();
		_interactionEnded?.Invoke();
		_interactionEnded = null;
	}

	void TryBuyItem(SavedOutfits savedOutfits, int index, int price)
	{
		if (_money.RuntimeValue >= price)
		{
			savedOutfits.AddOutfit(index);
		}
	}

	void BodySlotOnItemBought(int index, int price)
	{
		TryBuyItem(_savedBodies, index, price);
	}
	
	void HatSlotOnItemBought(int index, int price)
	{
		TryBuyItem(_savedHats, index, price);
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