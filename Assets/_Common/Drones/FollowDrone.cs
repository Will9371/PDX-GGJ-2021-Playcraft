using UnityEngine;

public class FollowDrone : MonoBehaviour
{
    [SerializeField] Transform self;
    [SerializeField] ZeroGravityMovement movement;
    [SerializeField] float pullMultiplier;
    [SerializeField] float stoppingDistance;
    [SerializeField] float maxPullStrength;
    [SerializeField] LineRenderer lineRenderer;

    Rigidbody rb;
    Vector3 targetDirection;
    Vector3 targetVector;
    float targetDistance;
    
    public Transform target;
    public void SetTarget(GameObject value) { target = value ? value.transform : null; }
    
    void Awake()
    {
        rb = self.GetComponent<Rigidbody>();
    }
    
    Vector3 _acceleration;
    float _deceleration;

    private void OnEnable()
    {
        lineRenderer.enabled = true;
        UpdateLineRenderer();
    }

    private void OnDisable()
    {
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (!target) return;

        UpdateLineRenderer();

        targetDirection = (target.position - self.position).normalized;
        targetDistance = Vector3.Distance(target.position, self.position);
        targetVector = Mathf.Sqrt(targetDistance) * targetDirection;
        
        if (targetDistance > stoppingDistance)
        {
            _acceleration = targetVector * pullMultiplier;
            
            if (_acceleration.magnitude > maxPullStrength)
                _acceleration = targetDirection * maxPullStrength;
            
            movement.Pull(_acceleration);
        }
        else if (rb.velocity.magnitude > .1f)
        {
            _deceleration = rb.velocity.magnitude * (stoppingDistance - targetDistance);
            movement.DragNoMax(_deceleration);
        }
    }

    void UpdateLineRenderer()
    {
        for (var i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, Vector3.Lerp(transform.position, target.position + Vector3.down * 0.5f, i / (lineRenderer.positionCount - 1)));
        }
    }
}
