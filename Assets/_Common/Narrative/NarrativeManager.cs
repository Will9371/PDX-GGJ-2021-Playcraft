using System;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField] SegmentData[] allSegments;
    
    public void FindSegment(NarrativeSegment segment)
    {
        allSegments[segment.index].found = true;
    }
    
    public string[] GetFoundText()
    {
        var result = new string[allSegments.Length];
        
        for (int i = 0; i < allSegments.Length; i++)
            result[i] = allSegments[i].found ? allSegments[i].segment.text : "";
            
        return result;
    }
    
    [Serializable] public struct SegmentData
    {
        public NarrativeSegment segment;
        public bool found;
    }
}
