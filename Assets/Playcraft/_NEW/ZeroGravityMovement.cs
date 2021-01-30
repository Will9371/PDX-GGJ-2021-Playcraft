using Playcraft;
using UnityEngine;
using UnityEngine.Events;

public class ZeroGravityMovement : MonoBehaviour
{
    public float thrust = 1f;
    public float drag = 1f;
    [SerializeField] Rigidbody rb;
    [SerializeField] UnityEvent OnAccelerate;
    [SerializeField] UnityEvent OnDecelerate;
    
    bool disabled;
    public void SetDisabled(bool value) { disabled = value; }
    
    void Awake()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
    }

    public void Accelerate(Vector3SO data) { Accelerate(data.value); } 
    void Accelerate(Vector3 direction)
    {
        if (disabled) return;
        var localDirection = rb.transform.TransformDirection(direction);
        rb.AddForce(thrust * localDirection, ForceMode.Force);
        OnAccelerate.Invoke();
    }
    
    public void Pull(Vector3 vector)
    {
        rb.AddForce(thrust * vector, ForceMode.Force);
    }
    
    // Use internal value
    public void Drag() { Drag(drag, true); }
    
    // Use external value
    public void Drag(float rate) { Drag(rate, true); }
    
    // Increase drag with movement speed
    public void DragNoMax(float rate) { Drag(rate, false); }
    
    Vector3 dragVector;
    
    void Drag(float rate, bool applyMax)
    {
        dragVector = -rb.velocity;
        
        // Decrease drag when slow to ease into a stop
        if (applyMax && dragVector.magnitude > 1) 
            dragVector = dragVector.normalized; 
            
        rb.AddForce(dragVector * rate, ForceMode.Force);
        OnDecelerate.Invoke();
    }
}
