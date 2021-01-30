using Playcraft;
using UnityEngine;

// Provides easy editor access to prefab settings
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
    [SerializeField] [Range(0f, 1f)] float shutoffEngineWhenBelow;
    [SerializeField] [Range(0f, 1f)] float reactivateEngineWhenAbove;
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
        emergencyShutdown.thresholds = new Vector2(shutoffEngineWhenBelow, reactivateEngineWhenAbove);
        
        mouseMovement.sensitivity = rotationSensitivity;
        mouseMovement.enabled = !useClickDrag;
        mouseInput.enabled = useClickDrag;
        
        pointLight.intensity = pointLightIntensity;
        pointLight.enabled = pointLightIntensity > 0f;
        spotLight.intensity = spotLightIntensity;
        spotLight.enabled = spotLightIntensity > 0f;
    }
}
