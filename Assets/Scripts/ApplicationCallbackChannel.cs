using BlueGravity.Save_System;
using UnityEngine;
namespace BlueGravity
{
	public class ApplicationCallbackChannel : MonoBehaviour
	{
		void OnApplicationPause(bool pauseStatus)
		{
			if (pauseStatus)
			{
				SaveManager.WriteToDisk();
			}
		}

		void OnApplicationQuit()
		{
			SaveManager.WriteToDisk();
		}
	}
}