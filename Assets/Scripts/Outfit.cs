using System;
using UnityEngine;

[Serializable]
public class Outfit
{
	[SerializeField] SpriteRenderer _outfitSprite;

	Sprite _defaultOutfitSprite;

	public ItemInfo WornItemInfo { get; private set; }

	public void SetupDefaultSprite()
	{
		_defaultOutfitSprite = _outfitSprite.sprite;
	}
	
	public void PreviewOutfit(Sprite sprite)
	{
		_outfitSprite.sprite = sprite == null ? _defaultOutfitSprite : sprite;
	}

	public void SetOutfit(ItemInfo itemInfo)
	{
		_outfitSprite.sprite = itemInfo.SpritePricePair.Sprite;
		WornItemInfo = itemInfo;
	}
	
	public void ResetOutfit()
	{
		_outfitSprite.sprite = _defaultOutfitSprite;
	}
}