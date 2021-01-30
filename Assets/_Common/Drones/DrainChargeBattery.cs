using UnityEngine;

public class DrainChargeBattery : MonoBehaviour
{
    [SerializeField] StoredFloatToPercent battery;
    [SerializeField] Rigidbody rb;
    
    public float thrustDrain;
    public float brakeDrain;
    public float minVelocityForBrakeDrain = 0.25f;
    
    float _thrustDrain => drain ? thrustDrain : 0f;
    float _brakeDrain => drain ? brakeDrain : 0f;
    
    bool drain = true;
    public void SetDrain(bool value) { drain = value; }
    
    public void Trust() { battery.AddOverTime(-_thrustDrain); }
    
    public void Brake() 
    {
        if (rb.velocity.magnitude < minVelocityForBrakeDrain) return; 
        battery.AddOverTime(-_brakeDrain); 
    }
}
