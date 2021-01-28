using Playcraft;
using UnityEngine;
using UnityEngine.Events;

public class ZeroGravityMovement : MonoBehaviour
{
    [SerializeField] float acceleration = 10f;
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
        rb.AddForce(acceleration * localDirection, ForceMode.Force);
        OnAccelerate.Invoke();
    }
}
