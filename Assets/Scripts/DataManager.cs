using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string highPlayerName;
    public int highScore;

    private void Awake()
    {
        // Prevents Duplicate Data Managers.
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
        public string highPlayerName;
    }

    public void SavePlayerName()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
    }

    public void ReadPlayerName(string inputName)
    {
        playerName = inputName;
    }

    public void SaveHighScore(int highScore, string playerName)
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highPlayerName = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highPlayerName = data.highPlayerName;
            
        }
    }
}
