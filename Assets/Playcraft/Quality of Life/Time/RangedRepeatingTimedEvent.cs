using UnityEngine;
using UnityEngine.Events;

public class RangedRepeatingTimedEvent : MonoBehaviour
{
    [Tooltip("Time between output events, varies with each iteration.  " +
             "Set the same values for X and Y to use a constant delay")]
    [SerializeField] Vector2 range;
    [SerializeField] UnityEvent Output;
    
    public void Begin() { Invoke(nameof(Act), RandomTime()); }
    public void End() { CancelInvoke(nameof(Act)); }
    
    void Act() 
    { 
        Output.Invoke();
        Invoke(nameof(Act), RandomTime());
    }
    
    float RandomTime() { return Random.Range(range.x, range.y); }    
}
