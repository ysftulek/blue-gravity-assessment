using Cinemachine;
using UnityEngine;
namespace BlueGravity
{
	[CreateAssetMenu(fileName = "Camera Tag", menuName = "Camera Tag", order = 0)]
	public class CameraTag : ScriptableObject
	{
		public static CinemachineVirtualCamera ActiveCam;

		CinemachineVirtualCamera _vcam;

		public void Register(CinemachineVirtualCamera vcam, bool isEnabled)
		{
			_vcam = vcam;
			if (isEnabled) ActiveCam = vcam;
		}

		public void Unregister()
		{
			_vcam = null;
		}

		public void Activate()
		{
			ActiveCam.enabled = false;
			_vcam.enabled = true;
			ActiveCam = _vcam;
		}
	}
}