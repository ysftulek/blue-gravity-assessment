using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
	[SerializeField] GameObject _hintPanel;
	[SerializeField] GameObject _shopPanel;
	
	public void EnableInteraction(Interactor interactor)
	{
		_hintPanel.SetActive(true);
	}
	
	public void DisableInteraction(Interactor interactor)
	{
		_hintPanel.SetActive(false);
		_shopPanel.SetActive(false);
	}
	
	public void Interact()
	{
		_shopPanel.SetActive(true);
	}
}