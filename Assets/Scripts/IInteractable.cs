using System;
public interface IInteractable
{
	void Interact(Interactor interactor, Action interactionEndedCallback);
}