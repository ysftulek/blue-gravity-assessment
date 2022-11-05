public interface IInteractable
{
	void EnableInteraction(Interactor interactor);
	void DisableInteraction(Interactor interactor);
	void Interact();
}