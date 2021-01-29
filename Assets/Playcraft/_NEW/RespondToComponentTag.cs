using System;
using Playcraft;
using UnityEngine;
using UnityEngine.Events;


public class RespondToComponentTag : MonoBehaviour
{
    [SerializeField] Binding[] bindings;
    
    public void Trigger(Collision other) { Trigger(other.collider); }
    public void Trigger(Collider other)
    {
        var otherTag = other.GetComponent<CustomTags>();
        if (!otherTag) return;
        
        foreach (var binding in bindings)
            if (otherTag.HasTag(binding.tag))
                binding.Response.Invoke(binding.tag);
    }
    
    [Serializable] public struct Binding
    {
        public SO tag;
        public SOEvent Response;
    }
}
