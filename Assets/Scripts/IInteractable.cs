using System;
namespace BlueGravity
{
	public interface IInteractable
	{
		void Interact(Interactor interactor, Action interactionEndedCallback);
	}
}