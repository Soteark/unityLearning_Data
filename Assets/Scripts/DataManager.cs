using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
