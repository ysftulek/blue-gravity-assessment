using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
	[SerializeField] GameObject _shopPanel;
	
	public void StartInteracting(Interactor interactor)
	{
		_shopPanel.SetActive(true);
	}
	
	public void StopInteracting(Interactor interactor)
	{
		_shopPanel.SetActive(false);
	}
}