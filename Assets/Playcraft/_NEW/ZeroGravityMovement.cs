using Playcraft;
using UnityEngine;
using UnityEngine.Events;

public class ZeroGravityMovement : MonoBehaviour
{
    public float thrust = 10f;
    [SerializeField] Rigidbody rb;
    [SerializeField] UnityEvent OnAccelerate;
    
    bool disabled;
    public void SetDisabled(bool value) { disabled = value; }
    
    void Awake()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
    }

    public void Accelerate(Vector3SO data) { Accelerate(data.value); } 
    public void Accelerate(Vector3 direction)
    {
        if (disabled) return;
        var localDirection = rb.transform.TransformDirection(direction);
        rb.AddForce(thrust * localDirection, ForceMode.Force);
        OnAccelerate.Invoke();
    }
    
    public void Drag(float rate)
    {
        var vector = -rb.velocity;
        
        // Decrease drag when slow to ease into a stop
        if (vector.magnitude > 1) 
            vector = vector.normalized; 
            
        rb.AddForce(vector * rate, ForceMode.Force);
    }
}
