using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
	[SerializeField] HintPanel _hintPanel;
	[SerializeField] GameObject _shopPanel;
	
	public void EnableInteraction(Interactor interactor)
	{
		_hintPanel.Show();
	}
	
	public void DisableInteraction(Interactor interactor)
	{
		_hintPanel.Hide();
		_shopPanel.SetActive(false);
	}
	
	public void Interact()
	{
		_shopPanel.SetActive(true);
	}
}