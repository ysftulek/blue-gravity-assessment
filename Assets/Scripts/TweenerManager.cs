using UnityEngine;

public class TweenerManager : MonoBehaviour
{
	[SerializeField] Mover _mover;
	[SerializeField] ScaleTweener _breathingScaleTweener;
	[SerializeField] ScaleTweener _walkingScaleTweener;
	
	void OnEnable()
	{
		_mover.MovingStarted += MoverOnMovingStarted;
		_mover.Stopped += MoverOnStopped;
	}

	void OnDisable()
	{
		_mover.MovingStarted -= MoverOnMovingStarted;
		_mover.Stopped -= MoverOnStopped;
	}

	void MoverOnMovingStarted()
	{
		_breathingScaleTweener.Stop();
		_walkingScaleTweener.Play();
	}

	void MoverOnStopped()
	{
		_walkingScaleTweener.Stop();
		_breathingScaleTweener.Play();
	}
}