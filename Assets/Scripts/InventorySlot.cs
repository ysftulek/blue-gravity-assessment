using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	[SerializeField] Image _itemImage;

	OutfitList _itemList;
	int _itemIndex;

	public void Initialize(ItemInfo itemInfo)
	{
		_itemList = itemInfo.ItemList;
		_itemIndex = itemInfo.ItemIndex;

		_itemImage.sprite = _itemList.GetOutfit(_itemIndex).Sprite;
		_itemImage.preserveAspect = true;
		_itemImage.enabled = true;
	}
}