using System;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField] SegmentData[] allSegments;
    [SerializeField] GameObject narrativePanel;
    
    void Start()
    {
        foreach (var segment in allSegments)
            segment.uiObject.Initialize(segment.segment);
    }
    
    public void FindSegment(NarrativeSegment segment)
    {
        allSegments[segment.index].found = true;
    }
    
    public void SetPanelActive(bool value)
    {
        narrativePanel.SetActive(value);
        if (value) RefreshDisplay();
    }
        
    public void RefreshDisplay()
    {    
        for (int i = 0; i < allSegments.Length; i++)
            allSegments[i].uiObject.SetActive(allSegments[i].found);
    }
    
    [Serializable] public struct SegmentData
    {
        public NarrativeSegment segment;
        public DisplayItemUI uiObject;
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
