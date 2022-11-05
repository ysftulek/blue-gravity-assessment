using UnityEngine;

public class OutfitManager : MonoBehaviour
{
	[SerializeField] SpriteRenderer _hat;
	[SerializeField] SpriteRenderer _body;

	public void SetHat(Sprite hatSprite)
	{
		_hat.sprite = hatSprite;
	}

	public void SetBody(Sprite bodySprite)
	{
		_body.sprite = bodySprite;
	}
}