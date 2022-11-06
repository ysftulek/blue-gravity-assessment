using UnityEngine;

public class Interactable : MonoBehaviour
{
	[SerializeField] HintPanel _hintPanel;

	public void EnableInteraction()
	{
		_hintPanel.Show();
	}

	public void DisableInteraction()
	{
		_hintPanel.Hide();
	}
}