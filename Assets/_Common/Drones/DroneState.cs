using UnityEngine;

public class DroneState : MonoBehaviour
{
    public bool active;
    public bool docked;
    public bool dead;
    
    [SerializeField] ZeroGravityMovement movement;
    
    public void SetDocked(bool value) { docked = value; }
    public void SetDead(bool value) { dead = value; movement.SetDisabled(value); }
}
