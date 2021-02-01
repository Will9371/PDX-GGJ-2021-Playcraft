using System;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField] SegmentData[] allSegments;
    
    public void FindSegment(NarrativeSegment segment)
    {
        allSegments[segment.index].found = true;
    }
    
    public void RefreshDisplay()
    {
        for (int i = 0; i < allSegments.Length; i++)
            allSegments[i].uiObject.SetActive(allSegments[i].found);
    }
    
    [Serializable] public struct SegmentData
    {
        public NarrativeSegment segment;
        public GameObject uiObject;
        public bool found;
    }
}

/*public string[] GetFoundText()
{
    var result = new string[allSegments.Length];
    
    for (int i = 0; i < allSegments.Length; i++)
        result[i] = allSegments[i].found ? allSegments[i].segment.text : "";
        
    return result;
}*/
