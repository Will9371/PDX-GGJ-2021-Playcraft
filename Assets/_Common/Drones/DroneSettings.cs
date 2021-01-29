using Playcraft;
using UnityEngine;

public class DroneSettings : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float mass;
    [SerializeField] float thrust;
    [Tooltip("Controlled by mouse movement")]
    [SerializeField] Vector2 rotationSensitivity;
    [Tooltip("If false: always rotate with mouse; if true, only rotate when left-button pressed")]
    [SerializeField] bool useClickDrag;
    [SerializeField] float maxBatteryCharge;
    [Tooltip("Disable movement when below X value, reactivate when above Y value")]
    [SerializeField] Vector2 engineActivationThresholds;
    [SerializeField] float pointLightIntensity;
    [SerializeField] float spotLightIntensity;
    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] ZeroGravityMovement movement;
    [SerializeField] GetMouseMovement mouseMovement;
    [SerializeField] GetMouseInput mouseInput;
    [SerializeField] StoredFloatToPercent battery;
    [SerializeField] BinaryThresholdComponent emergencyShutdown;
    [SerializeField] Light pointLight;
    [SerializeField] Light spotLight;

    void OnValidate() { Refresh(); }
    
    void Refresh()
    {
        rb.mass = mass;
        movement.thrust = thrust;
        battery.range = new Vector2(0, maxBatteryCharge);
        emergencyShutdown.thresholds = engineActivationThresholds;
        
        mouseMovement.sensitivity = rotationSensitivity;
        mouseMovement.enabled = !useClickDrag;
        mouseInput.enabled = useClickDrag;
        
        pointLight.intensity = pointLightIntensity;
        pointLight.enabled = pointLightIntensity > 0f;
        spotLight.intensity = spotLightIntensity;
        spotLight.enabled = spotLightIntensity > 0f;
    }
}
