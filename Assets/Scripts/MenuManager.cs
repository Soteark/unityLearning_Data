using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public DataManager dataMgr;

    void Start()
    {
        dataMgr = GameObject.Find("DataManager").GetComponent<DataManager>();
    }

    public void StartClick(int sceneIndex)
    {
        dataMgr.SavePlayerName();
        SceneManager.LoadScene(sceneIndex);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
