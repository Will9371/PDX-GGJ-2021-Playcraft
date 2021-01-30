using UnityEngine;

public class DrainChargeBattery : MonoBehaviour
{
    [SerializeField] StoredFloatToPercent battery;
    [SerializeField] ZeroGravityMovement engines;
    
    public float thrustDrain;
    public float brakeDrain;
    
    float _thrustDrain => drain ? thrustDrain : 0f;
    float _brakeDrain => drain ? brakeDrain : 0f;
    
    bool drain = true;
    public void SetDrain(bool value) { drain = value; }
    
    public void Trust() { battery.AddOverTime(-_thrustDrain); }
    public void Brake() { battery.AddOverTime(-_brakeDrain); }
}
