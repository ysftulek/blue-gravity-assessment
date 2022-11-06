using DG.Tweening;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
	[SerializeField] GameObject _shopPanelRoot;
	[SerializeField] Transform _scalableShopPanel;
	[SerializeField] ShopOutfitSlot _hatSlot;
	[SerializeField] ShopOutfitSlot _bodySlot;
	[SerializeField] Camera _outfitCam;

	public void Interact(Interactor interactor)
	{
		_shopPanelRoot.SetActive(true);
		_scalableShopPanel.DOComplete();
		_scalableShopPanel.localScale = Vector3.one * float.Epsilon;
		_scalableShopPanel.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
		_outfitCam.transform.position = interactor.transform.position + Vector3.back * 10f + Vector3.up * 0.5f;
		
		if (interactor.TryGetComponent(out OutfitManager outfitManager))
		{
			_hatSlot.Initialize(outfitManager.WornHatIndex);
			_bodySlot.Initialize(outfitManager.WornBodyIndex);
		}
	}
	
	public void HideShop()
	{
		_shopPanelRoot.SetActive(false);
	}
}