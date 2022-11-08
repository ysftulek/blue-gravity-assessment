using System;
using BlueGravity.Save_System;
using DG.Tweening;
using UnityEngine;
namespace BlueGravity
{
	public class ChestOpener : MonoBehaviour, IInteractable
	{
		[SerializeField] SpriteRenderer _spriteRenderer;
		[SerializeField] Sprite _interactedSprite;
		[SerializeField] SaveableRuntimeIntVariable _money;
		[SerializeField] int _moneyIncrease;

		bool _isInteracted;

		public void Interact(Interactor interactor, Action interactionEndedCallback)
		{
			transform.DOPunchScale(new Vector3(-0.3f,
						-0.5f,
						0),
					0.4f, 0, 0.3f)
				.OnComplete(() =>
				{
					transform.DOPunchScale(new Vector3(0.2f,
							0.5f,
							0f),
						0.2f, 2, 0.8f);
					_spriteRenderer.sprite = _interactedSprite;
					_money.RuntimeValue += _moneyIncrease;
				});
		
			interactionEndedCallback?.Invoke();
		}
	}
}