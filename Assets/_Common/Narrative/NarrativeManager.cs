using System;
using System.Collections.Generic;
using UnityEngine;
using Playcraft.Dialog;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField] SegmentData[] allSegments;
    public GameObject NarrativePanel;
    public TypewriterText TypewriterText;

    public void Show(NarrativeSegment segment)
    {
        allSegments[0].segment = segment;
        allSegments[0].found = true;
        NarrativePanel.SetActive(true);
    }

    public void TryDismiss()
    {
        if (TypewriterText.IsDone())
        {
            NarrativePanel.SetActive(false);
        }
        else
        {
            TypewriterText.Skip();
        }
    }
    
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
