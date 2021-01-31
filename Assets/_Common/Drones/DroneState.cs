using UnityEngine;

public class DroneState : MonoBehaviour
{
    [Tooltip("Prevent player from stranding Rescue Drone")]
    public bool canAlwaysActivate;
    [Tooltip("Currently controlled by the player")]
    public bool active;
    [Tooltip("In a recharge area")]
    public bool docked;
    [Tooltip("Outputs docked state when it changes")]
    public BoolEvent OnSetDocked;
    [Tooltip("Out of batteries, cannot move")]
    public bool dead;
    [Tooltip("Outputs dead state when it changes")]
    public BoolEvent OnSetDead;
    
    public bool canActivate => docked || active || canAlwaysActivate;
        
    public void SetDocked(bool value) 
    { 
        docked = value; 
        OnSetDocked.Invoke(value);
    }
    
    public void SetDead(bool value) 
    { 
        dead = value; 
        OnSetDead.Invoke(value); 
    }
}
