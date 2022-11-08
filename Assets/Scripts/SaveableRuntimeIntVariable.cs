using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Saveable Runtime Int Variable", menuName = "Saveable Runtime Int Variable", order = 0)]
public class SaveableRuntimeIntVariable : SaveableSO
{
	[SerializeField] int _initialValue;
	
	[NonSerialized] int _runtimeValue;

	public int RuntimeValue
	{
		get => _runtimeValue;
		set
		{
			_runtimeValue = value;
			ValueChanged?.Invoke(_runtimeValue);
			SaveManager.Save(this);
		}
	}
	public override object GetDefaultValue => _initialValue;

	public event Action<int> ValueChanged;
	
	public override void RestoreState(object obj)
	{
		RuntimeValue = (int)obj;
	}
	
	public override object CaptureState()
	{
		return RuntimeValue;
	}

	protected override void SceneManagerOnsceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		SaveManager.Restore(this);
	}
}