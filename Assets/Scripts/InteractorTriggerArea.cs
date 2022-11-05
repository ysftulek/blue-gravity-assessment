using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(IInteractable))]
public class InteractorTriggerArea : MonoBehaviour
{
	IInteractable _interactable;
	
	void Awake()
	{
		_interactable = GetComponent<IInteractable>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.TryGetComponent(out Interactor interactor))
		{
			_interactable.StartInteracting(interactor);
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.TryGetComponent(out Interactor interactor))
		{
			_interactable.StopInteracting(interactor);
		}
	}
}