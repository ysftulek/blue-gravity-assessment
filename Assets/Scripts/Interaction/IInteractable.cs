using System;

namespace BlueGravity.Interaction
{
	public interface IInteractable
	{
		void Interact(Interactor interactor, Action interactionEndedCallback);
	}
}