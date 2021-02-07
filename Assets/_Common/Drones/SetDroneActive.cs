using Playcraft;
using UnityEngine;

public class SetDroneActive : MonoBehaviour
{
    [SerializeField] GameObject cameraObject;
    [SerializeField] KeyboardInput movementInput;
    [SerializeField] TwoAxisRotation rotation;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject lights;
    [SerializeField] DrainChargeBattery battery;
    [SerializeField] KeyboardInput interactionInput;
    [SerializeField] FollowDrone follow;
    [SerializeField] GameObject lowBatterySound;
    [SerializeField] GameObject rechargeSound;
    [SerializeField] AudioSource followSound;
    [SerializeField] BoolEvent OnSetActive;

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
        
        if (!value)
        {
            follow.enabled = false;
            followSound.Stop();
        }
        
        // For drone-specific activations
        OnSetActive.Invoke(value);
    }
}
