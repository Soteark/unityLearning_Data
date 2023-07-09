using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;

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
}
