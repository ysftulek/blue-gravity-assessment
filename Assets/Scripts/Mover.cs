using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
	[SerializeField] InputChannel _inputChannel;
	[SerializeField] Rigidbody2D _rigidbody2D;
	[SerializeField, Tooltip("unit per seconds")] float _moveSpeed;

	Vector3 _moveVector;
	
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
		_rigidbody2D.velocity = _moveVector;
	}
	
	void InputChannelOnMoving(Vector2 obj)
	{
		Vector2 normalized = obj.normalized;
		_moveVector = normalized * _moveSpeed;
	}

	void InputChannelOnMovingFinished()
	{
		_moveVector = Vector3.zero;
	}
}