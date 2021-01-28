using Playcraft;
using UnityEngine;

public class ZeroGravityMovement : MonoBehaviour
{
    [SerializeField] float acceleration = 10f;
    [SerializeField] Rigidbody rb;
    
    void Awake()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3SO data) { Move(data.value); } 
    public void Move(Vector3 direction)
    {
        var localDirection = rb.transform.TransformDirection(direction);
        rb.AddForce(acceleration * localDirection, ForceMode.Force);
    }
}
