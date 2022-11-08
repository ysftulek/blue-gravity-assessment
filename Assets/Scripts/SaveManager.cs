using System.IO;
using UnityEngine;

public static class SaveManager
{
	static SaveData saveData;
	static readonly string SavePath = Path.Combine(Application.persistentDataPath, "gamedata.json");
	
	public static void RestoreInt(SaveableSO saveable)
	{
		saveData ??= File.Exists(SavePath) ? JsonUtility.FromJson<SaveData>(File.ReadAllText(SavePath)) : new SaveData();

		if (saveData.saves.ContainsKey(saveable.GetGuid))
		{
			saveable.RestoreState(saveData.saves[saveable.GetGuid]);
		}
		else
		{
			saveable.RestoreState(saveable.GetDefaultValue);
		}
	}

	public static void SaveInt(SaveableSO saveable)
	{
		if (saveData == null)
		{
			return;
		}
		
		if (saveData.saves.ContainsKey(saveable.GetGuid))
		{
			saveData.saves[saveable.GetGuid] = (int)saveable.CaptureState();
		}
		else
		{
			int value = (int)saveable.CaptureState();
			if (value != (int)saveable.GetDefaultValue)
			{
				saveData.saves.Add(saveable.GetGuid, value);
			}
		}
	}

	public static void WriteToDisk()
	{
		if (saveData == null)
		{
			return;
		}
		
		string convertedSaveData = JsonUtility.ToJson(saveData);
		File.WriteAllText(SavePath, convertedSaveData);
	}
}