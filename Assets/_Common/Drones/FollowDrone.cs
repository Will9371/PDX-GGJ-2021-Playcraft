using UnityEngine;

public class FollowDrone : MonoBehaviour
{
    [SerializeField] Transform self;
    [SerializeField] ZeroGravityMovement movement;
    [SerializeField] float pullMultiplier;
    [SerializeField] float stoppingDistance;
    [SerializeField] float maxPullStrength;
    
    Rigidbody rb;
    Vector3 targetDirection;
    Vector3 targetVector;
    float targetDistance;
    
    Transform target;
    public void SetTarget(GameObject value) { target = value ? value.transform : null; }
    
    void Awake()
    {
        rb = self.GetComponent<Rigidbody>();
    }
    
    Vector3 _acceleration;
    float _deceleration;
    
    void Update()
    {
        if (!target) return;
        
        targetDirection = (target.position - self.position).normalized;
        targetDistance = Vector3.Distance(target.position, self.position);
        targetVector = Mathf.Sqrt(targetDistance) * targetDirection;
        
        if (targetDistance > stoppingDistance)
        {
            _acceleration = targetVector * pullMultiplier;
            
            if (_acceleration.magnitude > maxPullStrength)
                _acceleration = targetDirection * maxPullStrength;
            
            movement.Accelerate(_acceleration);
        }
        else if (rb.velocity.magnitude > .1f)
        {
            _deceleration = rb.velocity.magnitude * (stoppingDistance - targetDistance);
            movement.DragNoMax(_deceleration);
        }
    }
}
