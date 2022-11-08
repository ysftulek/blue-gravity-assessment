using UnityEngine;
namespace BlueGravity
{
	public class DirectionChanger : MonoBehaviour
	{
		[SerializeField] InputChannel _inputChannel;
		[SerializeField] Transform _visualsToRotate;
		bool _isFacingRight;

		void OnEnable()
		{
			_inputChannel.Moving += InputChannelOnMoving;
		}

		void OnDisable()
		{
			_inputChannel.Moving -= InputChannelOnMoving;
		}
	
		void InputChannelOnMoving(Vector2 moveVector)
		{
			if (_isFacingRight && moveVector.x < 0f)
			{
				_isFacingRight = false;
				_visualsToRotate.eulerAngles = Vector3.zero;
			}
			else if (!_isFacingRight && moveVector.x > 0f)
			{
				_isFacingRight = true;
				_visualsToRotate.eulerAngles = new Vector3(0f, 180f, 0f);
			}

		}
	}
}