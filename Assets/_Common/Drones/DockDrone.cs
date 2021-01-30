using Playcraft;
using UnityEngine;

public class DockDrone : MonoBehaviour
{
    [SerializeField] SO[] dockingTags;
    [SerializeField] BoolEvent OnDock;

    void OnTriggerEnter(Collider other)
    {
        if (IsValidContact(other))
            OnDock.Invoke(true);
    }
    
    void OnTriggerExit(Collider other)
    {
        if (IsValidContact(other))
            OnDock.Invoke(false); 
    }
    
    bool IsValidContact(Collider other)
    {
        var tags = other.GetComponent<CustomTags>();
        if (!tags) return false;
        
        foreach (var ownItem in dockingTags)
        foreach (var otherItem in tags.tags)
            if (ownItem == otherItem)
                return true;
                
        return false;    
    }
}
