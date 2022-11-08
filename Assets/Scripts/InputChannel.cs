using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Input Channel", menuName = "Channels/Input Channel", order = 0)]
public class InputChannel : ScriptableObject
{
	public event Action<Vector2> Moving;
	public event Action MovingFinished;
	public event Action InteractionPressed;
	public event Action InventoryToggled;

	public void InvokeMoving(Vector2 moveVector)
	{
		Moving?.Invoke(moveVector);
	}

	public void InvokeMovingFinished()
	{
		MovingFinished?.Invoke();
	}
	
	public void InvokeInteraction()
	{
		InteractionPressed?.Invoke();
	}
	
	public void InvokeTogglingInventory()
	{
		InventoryToggled?.Invoke();
	}
}