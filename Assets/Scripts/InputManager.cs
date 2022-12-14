using UnityEngine;
namespace BlueGravity
{
	public class InputManager : MonoBehaviour
	{
		[SerializeField] InputChannel _inputChannel;
		[SerializeField] KeyCode _interactionKey;
		[SerializeField] KeyCode _inventoryKey;

		void Update()
		{
			if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
			{
				Vector2 moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
				_inputChannel.InvokeMoving(moveVector);
			}
		
			if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
			{
				_inputChannel.InvokeMovingFinished();
			}

			if (Input.GetKeyDown(_interactionKey))
			{
				_inputChannel.InvokeInteraction();
			}
		
			if (Input.GetKeyDown(_inventoryKey))
			{
				_inputChannel.InvokeTogglingInventory();
			}
		}
	}
}