using UnityEngine;

public class Interactor : MonoBehaviour
{
	[SerializeField] Mover _mover;
	[SerializeField] KeyCode _interactionKey;
	
	Interactable _interactable;
	
	void Update()
	{
		if (_interactable)
		{
			if (Input.GetKeyDown(_interactionKey))
			{
				_interactable.GetComponent<IInteractable>().Interact(this);
				_mover.enabled = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.TryGetComponent(out Interactable interactable))
		{
			_interactable = interactable;
			interactable.EnableInteraction();
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.TryGetComponent(out Interactable interactable))
		{
			_interactable = null;
			interactable.DisableInteraction();
		}
	}
}