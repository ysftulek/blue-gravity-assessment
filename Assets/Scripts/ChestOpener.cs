using System;
using UnityEngine;

public class ChestOpener : MonoBehaviour, IInteractable
{
	[SerializeField] SpriteRenderer _spriteRenderer;
	[SerializeField] Sprite _interactedSprite;

	bool _isInteracted;

	public void Interact(Interactor interactor, Action interactionEndedCallback)
	{
		_spriteRenderer.sprite = _interactedSprite;
		
		interactionEndedCallback?.Invoke();
	}
}