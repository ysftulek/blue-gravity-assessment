using System;
using TMPro;
using UnityEngine;

public class IntMonitor : MonoBehaviour
{
	[SerializeField] SaveableRuntimeIntVariable _intVariable;
	[SerializeField] TextMeshProUGUI _monitoredText;
	[SerializeField] string _prefix;

	void OnEnable()
	{
		_intVariable.ValueChanged += IntVariableOnValueChanged;
		IntVariableOnValueChanged(_intVariable.RuntimeValue);
	}

	void OnDisable()
	{
		_intVariable.ValueChanged -= IntVariableOnValueChanged;
	}
	
	void IntVariableOnValueChanged(int obj)
	{
		_monitoredText.text = _prefix + obj;
	}
}