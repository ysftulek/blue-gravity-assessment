using System;
using System.Collections.Generic;
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

	List<int> _obtainedOutfitIndex;
	int _outfitIndex;
	
	public event Action<int, int> ItemBought;
	public event Action<Sprite> ItemUpdated;

	public void Initialize(int wornIndex, List<int> obtainedOutfitIndex)
	{
		_outfitIndex = wornIndex;
		_obtainedOutfitIndex = obtainedOutfitIndex;
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
		if (!_obtainedOutfitIndex.Contains(_outfitIndex))
		{
			ItemBought?.Invoke(_outfitIndex, _outfitList.GetOutfit(_outfitIndex).Price);
			UpdateAllImages();
		}
	}

	int IncreaseIndex(int index)
	{
		index++;
		if (index >= _outfitList.Count())
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
			index = _outfitList.Count() - 1;
		}
		return index;
	}
	
	void UpdateAllImages()
	{
		UpdateImage(_itemImage, _outfitIndex);
		SetPrice(_outfitIndex);
		if (_outfitIndex == 0)
		{
			ItemUpdated?.Invoke(null);
		}
		else
		{
			ItemUpdated?.Invoke(_outfitList.GetOutfit(_outfitIndex).Sprite);
		}
		UpdateImage(_previousItemImage, DecreaseIndex(_outfitIndex));
		UpdateImage(_nextItemImage, IncreaseIndex(_outfitIndex));
	}
	
	void UpdateImage(SlotImage previewSlot, int index)
	{
		SpritePricePair pair = _outfitList.GetOutfit(index);
		previewSlot.PreviewImage.sprite = pair.Sprite;

		if (_obtainedOutfitIndex.Contains(index))
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
		if (index == 0)
		{
			_itemPrice.text = string.Empty;
		}
		else
		{
			_itemPrice.text = "<size=30>$</size>" + _outfitList.GetOutfit(index).Price;
		}
	}

	[Serializable]
	struct SlotImage
	{
		public Image PreviewImage;
		public Image SoldImage;
	}
}