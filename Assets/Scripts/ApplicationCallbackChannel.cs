using System;
using UnityEngine;

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