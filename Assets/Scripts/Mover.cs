using System;
using UnityEngine;
namespace BlueGravity
{
	public class Mover : MonoBehaviour
	{
		[SerializeField] InputChannel _inputChannel;
		[SerializeField] Rigidbody2D _rigidbody2D;
		[SerializeField, Tooltip("unit per seconds")] float _moveSpeed;

		Vector3 _moveVector;
		bool _canMove = true;

		public event Action MovingStarted;
		public event Action Stopped;
	
		void OnEnable()
		{
			_inputChannel.Moving += InputChannelOnMoving;
			_inputChannel.MovingFinished += InputChannelOnMovingFinished;
		}

		void OnDisable()
		{
			_inputChannel.Moving -= InputChannelOnMoving;
			_inputChannel.MovingFinished -= InputChannelOnMovingFinished;
		}

		void FixedUpdate()
		{
			if (!_canMove)
			{
				_rigidbody2D.velocity = Vector2.zero;
				return;
			}
		
			_rigidbody2D.velocity = _moveVector;
		}

		public void SetActiveMovement(bool state)
		{
			_canMove = state;
		}
	
		void InputChannelOnMoving(Vector2 obj)
		{
			if (_canMove && _moveVector == Vector3.zero)
			{
				MovingStarted?.Invoke();
			}
		
			Vector2 normalized = obj.normalized;
			_moveVector = normalized * _moveSpeed;
		}

		void InputChannelOnMovingFinished()
		{
			if (_canMove)
			{
				Stopped?.Invoke();
			}
			_moveVector = Vector3.zero;
		}
	}
}