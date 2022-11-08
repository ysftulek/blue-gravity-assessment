using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopOutfitSlotBuyer : MonoBehaviour, IPointerDownHandler
{
	[SerializeField] ShopOutfitSlot _shopOutfitSlot;

	public void OnPointerDown(PointerEventData eventData)
	{
		_shopOutfitSlot.BuyItem();
	}
}