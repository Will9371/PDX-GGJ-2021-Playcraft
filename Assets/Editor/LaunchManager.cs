using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

[InitializeOnLoad]
public class LaunchManager
{
    static LaunchManager()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    static void OnPlayModeStateChanged(PlayModeStateChange change)
    {
        if (change == PlayModeStateChange.EnteredPlayMode && SceneManager.sceneCount == 1)
        {
            var launchInfo = Resources.Load("LaunchInfo") as LaunchInfo;
            launchInfo.StartingScene = SceneManager.GetActiveScene().name;
            EditorUtility.SetDirty(launchInfo);
            AssetDatabase.SaveAssets();

            SceneManager.LoadScene("System");
        }
    }
}
