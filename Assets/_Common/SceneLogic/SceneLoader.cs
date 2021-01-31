using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string StartingSceneForBuilds;
    public List<GameObject> DronePrefabs;
    public SetActiveDrone DroneActivator;
    public NarrativeManager NarrativeManager;

    string StartingScene;
    List<GameObject> Drones = new List<GameObject>();

    void Start()
    {
        SceneManager.sceneLoaded += InitializeNewScene;

        StartingScene = StartingSceneForBuilds;
        if (Application.isEditor)
        {
            var launchInfo = Resources.Load("LaunchInfo") as LaunchInfo;
            if (launchInfo != null && launchInfo.StartingScene != "System")
            {
                StartingScene = launchInfo.StartingScene;
            }
        }
        SceneManager.LoadScene(StartingScene, LoadSceneMode.Additive);
    }

    public void RestartScene()
    {
        var unloadProcess = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        unloadProcess.completed += HandleUnload;
    }

    void HandleUnload(AsyncOperation op)
    {
        SceneManager.LoadScene(StartingScene, LoadSceneMode.Additive);
    }

    void InitializeNewScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);

        SceneSetupInfo setupInfo = null;
        var rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var rootObject in rootObjects)
        {
            setupInfo = rootObject.GetComponentInChildren<SceneSetupInfo>();
            if (setupInfo != null)
            {
                break;
            }
        }

        for (var i = 0; i < DronePrefabs.Count; i++)
        {
            var startingPosition = Vector3.zero;
            var startingRotation = Quaternion.identity;
            if (setupInfo != null && i < setupInfo.StartingPositions.Count)
            {
                startingPosition = setupInfo.StartingPositions[i].position;
                startingRotation = setupInfo.StartingPositions[i].rotation;
            }
            var newDrone = Instantiate(DronePrefabs[i]);
            newDrone.transform.position = startingPosition;
            newDrone.transform.rotation = startingRotation;

            Drones.Add(newDrone);

            if (i < DroneActivator.droneData.Length)
            {
                DroneActivator.droneData[i].drone = newDrone.GetComponentInChildren<SetDroneActive>();
            }
        }
        DroneActivator.SetActiveDroneByIndex();

        setupInfo.GetComponentInChildren<NarrativeRelay>().NarrativeManager = NarrativeManager;
    }
}
