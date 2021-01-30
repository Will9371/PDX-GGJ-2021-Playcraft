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
    
    Camera cam;
    AudioListener sound;
    DroneState state;
    
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
    }
}
