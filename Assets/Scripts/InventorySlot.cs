using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace BlueGravity
{
	public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] Image _itemImage;
		[SerializeField] Image _sellImageForeground;
		[SerializeField] Image _sellImageBackground;

		InventoryUI _inventoryUI;
		ItemInfo _itemInfo;

		public void Initialize(InventoryUI inventoryUI, ItemInfo itemInfo)
		{
			_inventoryUI = inventoryUI;
			_itemInfo = itemInfo;
		
			_itemImage.sprite = itemInfo.SpritePricePair.Sprite;
			_itemImage.preserveAspect = true;
			_itemImage.enabled = true;
		}
	
		public void OnPointerDown(PointerEventData eventData)
		{
			SellItem();
		}

		void SellItem()
		{
			_inventoryUI.SellItem(_itemInfo);
			_itemInfo = new ItemInfo();
			_itemImage.sprite = null;
			_itemImage.enabled = false;
		}
	
		public void OnPointerEnter(PointerEventData eventData)
		{
			bool isItemExist = _itemImage.enabled;
			_sellImageForeground.enabled = isItemExist;
			_sellImageBackground.enabled = isItemExist;
		}
	
		public void OnPointerExit(PointerEventData eventData)
		{
			_sellImageForeground.enabled = false;
			_sellImageBackground.enabled = false;
		}
	}
}