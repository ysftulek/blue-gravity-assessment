using UnityEngine;
using UnityEngine.UI;

public class ShopOutfitSlot : MonoBehaviour
{
	[SerializeField] Image _itemImage;
	[SerializeField] OutfitList _outfitList;
	[SerializeField] Sprite _emptySlotSprite;

	int _outfitIndex;
	
	public void Initialize(int wornIndex)
	{
		_outfitIndex = wornIndex;
		UpdateImage();
	}

	public void ShowNextOutfit()
	{
		_outfitIndex++;
		if (_outfitIndex >= _outfitList.Count())
		{
			_outfitIndex = 0;
		}
		UpdateImage();
	}
	
	public void ShowPreviousOutfit()
	{
		_outfitIndex--;
		if (_outfitIndex < 0)
		{
			_outfitIndex = _outfitList.Count();
		}
		UpdateImage();
	}

	void UpdateImage()
	{
		if (_outfitIndex == 0)
		{
			_itemImage.sprite = _emptySlotSprite;
			return;
		}
		_itemImage.sprite = _outfitList.GetOutfit(_outfitIndex);
	}
}