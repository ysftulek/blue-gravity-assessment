using UnityEngine;

public class OutfitManager : MonoBehaviour
{
	[SerializeField] SpriteRenderer _hat;
	[SerializeField] SpriteRenderer _body;

	public int WornHatIndex { get; private set; }
	public int WornBodyIndex { get; private set; }
	
	public void SetHat(Sprite hatSprite, int hatIndex)
	{
		_hat.sprite = hatSprite;
		WornHatIndex = hatIndex;
	}

	public void SetBody(Sprite bodySprite, int bodyIndex)
	{
		_body.sprite = bodySprite;
		WornBodyIndex = bodyIndex;
	}
}