using System;
using UnityEngine;

[Serializable]
public class Outfit
{
	[SerializeField] SpriteRenderer _outfitSprite;

	Sprite _defaultOutfitSprite;

	public int WornOutfitIndex { get; private set; }

	public void Initialize()
	{
		_defaultOutfitSprite = _outfitSprite.sprite;
	}
	
	public void PreviewOutfit(Sprite sprite)
	{
		_outfitSprite.sprite = sprite == null ? _defaultOutfitSprite : sprite;
	}

	public void SetOutfit(Sprite sprite, int index)
	{
		_outfitSprite.sprite = sprite;
		WornOutfitIndex = index;
	}
	
	public void ResetOutfit()
	{
		_outfitSprite.sprite = _defaultOutfitSprite;
	}
}