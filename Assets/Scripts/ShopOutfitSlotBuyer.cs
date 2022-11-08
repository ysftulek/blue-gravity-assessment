using UnityEngine;
using UnityEngine.EventSystems;
namespace BlueGravity
{
	public class ShopOutfitSlotBuyer : MonoBehaviour, IPointerDownHandler
	{
		[SerializeField] ShopOutfitSlot _shopOutfitSlot;

		public void OnPointerDown(PointerEventData eventData)
		{
			_shopOutfitSlot.BuyItem();
		}
	}
}