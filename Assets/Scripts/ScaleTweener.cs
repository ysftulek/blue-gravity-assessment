using DG.Tweening;
using UnityEngine;

public class ScaleTweener : MonoBehaviour
{
	[SerializeField] Transform _animatedTransform;
	[SerializeField] Vector3 _scaleAmount0 = new Vector3(0.04f, 0.08f, 0f);
	[SerializeField] float _duration;
	
	Tweener _tweener;

	void Awake()
	{
		_tweener = _animatedTransform.DOPunchScale(_scaleAmount0,
				_duration,
				0,
				0.5f)
			.SetLoops(-1)
			.SetAutoKill(false)
			.Pause();
	}
	
	public void Play()
	{
		_tweener.Restart();
	}

	public void Stop()
	{
		_tweener.Rewind();
	}
}