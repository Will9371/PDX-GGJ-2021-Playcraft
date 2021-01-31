using UnityEngine;

public class DrainChargeBattery : MonoBehaviour
{
    [SerializeField] StoredFloatToPercent battery;
    [SerializeField] Rigidbody rb;
    
    public float thrustDrain;
    public float brakeDrain;
    public float minVelocityForBrakeDrain = 0.25f;
    [Range(0, 1)] public float lowBatteryThreshold = .25f;
    
    [SerializeField] BoolEvent LowBattery;
    
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
    
    void Update()
    {
        CheckBattery();
    }
    
    bool wasLowBattery;
    bool isLowBattery;
    
    void CheckBattery()
    {
        isLowBattery = battery.percent < lowBatteryThreshold && battery.percent > .011f;
        
        if (wasLowBattery != isLowBattery)
        {
            LowBattery.Invoke(isLowBattery);
            wasLowBattery = isLowBattery;
        }
    }
}
