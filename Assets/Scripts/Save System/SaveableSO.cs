using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlueGravity.Save_System
{
	public abstract class SaveableSO : ScriptableObject
	{
		[SerializeField, HideInInspector]  string _guid;

		public string GetGuid => _guid;

		public abstract object GetDefaultValue { get; }

#if UNITY_EDITOR
		void OnValidate()
		{
			string path = AssetDatabase.GetAssetPath(this);
			_guid = AssetDatabase.AssetPathToGUID(path);
		}
#endif

		public abstract void RestoreState(object obj);

		public abstract object CaptureState();

		void OnEnable()
		{
			SceneManager.sceneLoaded += SceneManagerOnsceneLoaded;
		}
	
		void OnDisable()
		{
			SceneManager.sceneLoaded -= SceneManagerOnsceneLoaded;
		}

		protected abstract void SceneManagerOnsceneLoaded(Scene arg0, LoadSceneMode arg1);
	}
}