using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[SerializeField] HintPanel _hintPanel;
	[SerializeField] bool _interactOnce;

	IInteractable _interactable;

	void Awake()
	{
		_interactable = GetComponent<IInteractable>();
	}

	public void EnableInteraction()
	{
		_hintPanel.Show();
	}

	public void DisableInteraction()
	{
		_hintPanel.Hide();
	}

	public void Interact(Interactor interactor, Action onInteractionEnded)
	{
		_interactable.Interact(interactor, onInteractionEnded);

		if (_interactOnce)
		{
			DisableInteraction();
			Destroy(this);
		}
	}
}