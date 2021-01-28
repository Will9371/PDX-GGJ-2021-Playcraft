using Playcraft;
using UnityEngine;
using UnityEngine.Events;

// * Generalize to include multiple tags/responses
public class RespondToComponentTag : MonoBehaviour
{
    #pragma warning disable 0649
    [SerializeField] SO respondToTag;
    [SerializeField] UnityEvent Response;
    #pragma warning restore 0649
    
    public void Trigger(Collision other) { Trigger(other.collider); }
    public void Trigger(Collider other)
    {
        var otherTag = other.GetComponent<CustomTags>();
        if (otherTag && otherTag.HasTag(respondToTag))
            Response.Invoke();
    }
}
