using System;
using UnityEngine;

public class Interactor : MonoBehaviour
{
	IInteractable _interactable;
	bool _canInteract;
	
	void Update()
	{
		if (_canInteract)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				_interactable.Interact();
			}
		}
	}

	public void EnableInteraction(IInteractable interactable)
	{
		_interactable = interactable;
		_canInteract = true;
	}
	
	public void DisableInteraction()
	{
		_interactable = null;
		_canInteract = false;
	}
}