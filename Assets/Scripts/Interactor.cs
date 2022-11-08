using UnityEngine;
namespace BlueGravity
{
	public class Interactor : MonoBehaviour
	{
		[SerializeField] Mover _mover;
		[SerializeField] InputChannel _inputChannel;
	
		Interactable _interactable;
		bool _interacted;

		void OnEnable()
		{
			_inputChannel.InteractionPressed += InputChannelOnInteractionPressed;
		}

		void OnDisable()
		{
			_inputChannel.InteractionPressed -= InputChannelOnInteractionPressed;
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
	
		void InputChannelOnInteractionPressed()
		{
			if (!_interactable || _interacted)
				return;
		
			OnInteractionStarting();
			_interactable.Interact(this, OnInteractionEnded);
		}

		void OnInteractionStarting()
		{
			_mover.SetActiveMovement(false);
			_interacted = true;
		}

		void OnInteractionEnded()
		{
			_mover.SetActiveMovement(true);
			_interacted = false;
		}
	}
}