using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraTagMono : MonoBehaviour
{
	[SerializeField] CameraTag _cameraTag;

	CinemachineVirtualCamera _virtualCamera;

	void OnEnable()
	{
		_virtualCamera = GetComponent<CinemachineVirtualCamera>();
		_cameraTag.Register(_virtualCamera, _virtualCamera.enabled);
	}

	void OnDisable()
	{
		_cameraTag.Unregister();
	}
}