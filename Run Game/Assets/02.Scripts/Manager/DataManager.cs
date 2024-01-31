using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Data 
{
    public int score;
}

public class DataManager : Singleton<DataManager>
{
    public Data data = new();

    void Start()
    {
        Load();
        Debug.Log(data.score);
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(data);

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);

        string code = System.Convert.ToBase64String(bytes);

        File.WriteAllText(Application.persistentDataPath + "/GameData.json", code);
    }

    public void Load() 
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/GameData.json");

        byte[] bytes = System.Convert.FromBase64String(jsonData);

        string code = System.Text.Encoding.UTF8.GetString(bytes);

        data = JsonUtility.FromJson<Data>(code);
    }
}
