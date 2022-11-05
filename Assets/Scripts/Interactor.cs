using System;
using UnityEngine;

public class Interactor : MonoBehaviour
{
	[SerializeField] KeyCode _interactionKey;
	
	IInteractable _interactable;
	bool _canInteract;
	
	void Update()
	{
		if (_canInteract)
		{
			if (Input.GetKeyDown(_interactionKey))
			{
				_interactable.Interact();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.TryGetComponent(out IInteractable interactable))
		{
			_interactable = interactable;
			_canInteract = true;
			interactable.EnableInteraction();
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.TryGetComponent(out IInteractable interactable))
		{
			_interactable = null;
			_canInteract = false;
			interactable.DisableInteraction();
		}
	}
	
	void DisableInteraction()
	{
		_interactable = null;
		_canInteract = false;
	}
}