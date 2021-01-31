using Playcraft;
using UnityEngine;
//using UnityEngine.Events;

public class SetDroneActive : MonoBehaviour
{
    [SerializeField] GameObject cameraObject;
    [SerializeField] KeyboardInput movementInput;
    [SerializeField] TwoAxisRotation rotation;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject lights;
    [SerializeField] DrainChargeBattery battery;
    [SerializeField] KeyboardInput interactionInput;
    [SerializeField] KeyboardInput beaconLauncher;
    [SerializeField] FollowDrone follow;
    [SerializeField] GameObject lowBatterySound;
    [SerializeField] GameObject rechargeSound;

    Camera cam;
    AudioListener sound;
    public DroneState state;
    
    void Awake()
    {
        state = gameObject.GetComponent<DroneState>();
        cam = cameraObject.GetComponent<Camera>();
        sound = cameraObject.GetComponent<AudioListener>();
    }
    
    public void SetActive(bool value)
    {
        state.active = value;
        cam.enabled = value;
        sound.enabled = value;
        movementInput.enabled = value;
        interactionInput.enabled = value;
        rotation.SetEnabled(value);
        HUD.SetActive(value);
        lights.SetActive(value);
        battery.SetDrain(value);
        lowBatterySound.SetActive(value);
        rechargeSound.SetActive(value);
        
        if (beaconLauncher)
        {
            beaconLauncher.enabled = value;
        }
        
        if (value)
        {
            follow.enabled = false;
        }
        //Debug.Log((deactivationAction != null) + ", " + value);
        //if (deactivationAction && !value)
        //{
        //    Debug.Log("Triggering deactivation action");
        //    deactivationAction.Interact(false);
        //}
    }
}
