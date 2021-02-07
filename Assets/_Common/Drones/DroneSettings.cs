using Playcraft;
using UnityEngine;

// Provides easy editor access to prefab settings
public class DroneSettings : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float mass;
    [Tooltip("Acceleration (affected by mass) to apply when moving forward or back")]
    [SerializeField] float thrust;
    [Tooltip("Deceleration (affected by mass) to apply when braking")]
    [SerializeField] float drag;
    [SerializeField] float interactionDistance;
    [SerializeField] float maxBatteryCharge;
    [SerializeField] [Range(0f, 1f)] float shutoffEngineWhenBelow;
    [SerializeField] [Range(0f, 1f)] float reactivateEngineWhenAbove;
    [Tooltip("Set to 0 to disable point light")]
    [SerializeField] float pointLightIntensity;
    [SerializeField] float pointLightRange;
    [Tooltip("Set to 0 to disable spot light")]
    [SerializeField] float spotLightIntensity;
    
    [Header("Settings")]
    [Tooltip("Controlled by mouse movement")]
    [SerializeField] Vector2 rotationSensitivity;
    [Tooltip("If false: always rotate with mouse; if true, only rotate when left-button pressed")]
    [SerializeField] bool useClickDrag;
    
    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] ZeroGravityMovement movement;
    [SerializeField] GetMouseMovement mouseMovement;
    [SerializeField] GetMouseInput mouseInput;
    [SerializeField] ScreenRaycast interactionRaycast;
    [SerializeField] StoredFloatToPercent battery;
    [SerializeField] BinaryThresholdComponent emergencyShutdown;
    [SerializeField] Light pointLight;
    [SerializeField] Light spotLight;

    void OnValidate() { Refresh(); }
    
    void Refresh()
    {
        rb.mass = mass;
        movement.thrust = thrust;
        movement.drag = drag;
        battery.range = new Vector2(0, maxBatteryCharge);
        emergencyShutdown.thresholds = new Vector2(shutoffEngineWhenBelow, reactivateEngineWhenAbove);
        
        interactionRaycast.range = interactionDistance;
        
        mouseMovement.sensitivity = rotationSensitivity;
        mouseMovement.enabled = !useClickDrag;
        mouseInput.enabled = useClickDrag;
        
        pointLight.intensity = pointLightIntensity;
        pointLight.range = pointLightRange;
        pointLight.enabled = pointLightIntensity > 0f;

        spotLight.intensity = spotLightIntensity;
        spotLight.enabled = spotLightIntensity > 0f;
    }
}
