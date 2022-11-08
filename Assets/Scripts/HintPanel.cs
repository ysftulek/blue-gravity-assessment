using DG.Tweening;
using TMPro;
using UnityEngine;
namespace BlueGravity
{
	public class HintPanel : MonoBehaviour
	{
		[SerializeField] TextMeshPro _hintText;
		[SerializeField] SpriteRenderer _hintArrow;

		const float FADE_DURATION = 1f;
	
		public void Show()
		{
			gameObject.SetActive(true);
			transform.DOComplete();
			transform.DOPunchPosition(Vector3.down * 0.15f, 0.5f, 0, 0f);

			FadeInAll();
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
	
		void FadeInAll()
		{
			_hintText.DOComplete();
			_hintArrow.DOComplete();
		
			_hintText.alpha = 0f;
			_hintText.DOFade(1f, FADE_DURATION);
			Color color = _hintArrow.color;
			color.a = 0f;
			_hintArrow.color = color;
			_hintArrow.DOFade(1f, FADE_DURATION);
		}
	}
}