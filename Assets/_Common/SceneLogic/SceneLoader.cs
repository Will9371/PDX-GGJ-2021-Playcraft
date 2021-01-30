using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string StartingSceneForBuilds;
    public GameObject BaseDronePrefab;
    public GameObject RescueDronePrefab;
    public SetActiveDrone DroneActivator;

    List<GameObject> Drones = new List<GameObject>();

    void Start()
    {
        SceneManager.sceneLoaded += InitializeNewScene;

        var startingScene = StartingSceneForBuilds;
        if (Application.isEditor)
        {
            var launchInfo = Resources.Load("LaunchInfo") as LaunchInfo;
            if (launchInfo != null && launchInfo.StartingScene != "System")
            {
                startingScene = launchInfo.StartingScene;
            }
        }
        SceneManager.LoadScene(startingScene, LoadSceneMode.Additive);
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

        var prefabsToInstantiate = new[] { BaseDronePrefab, RescueDronePrefab };
        for (var i = 0; i < prefabsToInstantiate.Length; i++)
        {
            var startingPosition = Vector3.zero;
            var startingRotation = Quaternion.identity;
            if (setupInfo != null && i < setupInfo.StartingPositions.Count)
            {
                startingPosition = setupInfo.StartingPositions[i].position;
                startingRotation = setupInfo.StartingPositions[i].rotation;
            }
            var newDrone = Instantiate(prefabsToInstantiate[i]);
            newDrone.transform.position = startingPosition;
            newDrone.transform.rotation = startingRotation;

            Drones.Add(newDrone);

            if (i < DroneActivator.droneData.Length)
            {
                DroneActivator.droneData[i].drone = newDrone.GetComponentInChildren<SetDroneActive>();
            }
        }
        DroneActivator.SetActiveDroneByIndex();
    }
}
