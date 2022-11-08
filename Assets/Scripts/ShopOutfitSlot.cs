using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopOutfitSlot : MonoBehaviour
{
	[SerializeField] SlotImage _itemImage;
	[SerializeField] SlotImage _nextItemImage;
	[SerializeField] SlotImage _previousItemImage;
	[SerializeField] TextMeshProUGUI _itemPrice;
	[SerializeField] OutfitList _outfitList;

	int _outfitIndex;

	public ItemInfo GetSelectedItem => _outfitList.GetItemInfo(_outfitIndex);
	
	public event Action<ItemInfo> ItemBought;
	public event Action<Sprite> ItemUpdated;

	public void Initialize()
	{
		UpdateAllImages();
	}

	public void ShowNextOutfit()
	{
		_outfitIndex = IncreaseIndex(_outfitIndex);
		UpdateAllImages();
	}
	
	public void ShowPreviousOutfit()
	{
		_outfitIndex = DecreaseIndex(_outfitIndex);
		UpdateAllImages();
	}

	public void BuyItem()
	{
		if (_outfitList.GetItem(_outfitIndex).RuntimeValue == 0)
		{
			ItemBought?.Invoke(_outfitList.GetItemInfo(_outfitIndex));
			UpdateAllImages();
		}
	}

	int IncreaseIndex(int index)
	{
		index++;
		if (index >= _outfitList.Count)
		{
			index = 0;
		}
		return index;
	}
	
	int DecreaseIndex(int index)
	{
		index--;
		if (index < 0)
		{
			index = _outfitList.Count - 1;
		}
		return index;
	}
	
	void UpdateAllImages()
	{
		UpdateImage(_itemImage, _outfitIndex);
		SetPrice(_outfitIndex);
		if (_outfitIndex == 0)
		{
			//ItemUpdated?.Invoke(null);
		}
		else
		{
			//ItemUpdated?.Invoke(_outfitList.GetOutfitInfo(_outfitIndex).Sprite);
		}
		
		ItemUpdated?.Invoke(_outfitList.GetOutfitInfo(_outfitIndex).Sprite);

		UpdateImage(_previousItemImage, DecreaseIndex(_outfitIndex));
		UpdateImage(_nextItemImage, IncreaseIndex(_outfitIndex));
	}
	
	void UpdateImage(SlotImage previewSlot, int index)
	{
		ItemInfo itemInfo = _outfitList.GetItemInfo(index);
		previewSlot.PreviewImage.sprite = itemInfo.SpritePricePair.Sprite;

		if (itemInfo.Item.RuntimeValue == 1)
		{
			previewSlot.SoldImage.enabled = true;
			previewSlot.PreviewImage.SetAlpha(0.5f);
		}
		else
		{
			previewSlot.SoldImage.enabled = false;
			previewSlot.PreviewImage.SetAlpha(1f);
		}
	}

	void SetPrice(int index)
	{
		_itemPrice.text = "<size=30>$</size>" + _outfitList.GetOutfitInfo(index).Price;
	}

	[Serializable]
	struct SlotImage
	{
		public Image PreviewImage;
		public Image SoldImage;
	}
}