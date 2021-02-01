using System;
using UnityEngine;
using Playcraft.Dialog;
using UnityEngine.Events;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField] SegmentData[] ProgressSegments;
    [SerializeField] GameObject DialogPanel;
    [SerializeField] GameObject ProgressPanel;
    public TypewriterText TypewriterText;
    public string DialogMessage;
    [SerializeField] UnityEvent OnAllFound;

    public void Show(NarrativeSegment segment)
    {
        DialogMessage = segment.description;
        DialogPanel.SetActive(true);
    }

    public void TryDismiss()
    {
        if (TypewriterText.IsDone())
        {
            DialogPanel.SetActive(false);
        }
        else
        {
            TypewriterText.Skip();
        }
    }
    
    void Start()
    {
        foreach (var segment in ProgressSegments)
            segment.uiObject.Initialize(segment.segment);
    }
    
    public void FindSegment(NarrativeSegment segment)
    {
        ProgressSegments[segment.index].found = true;
    }
    
    public void SetPanelActive(bool value)
    {
        ProgressPanel.SetActive(value);
        if (value) RefreshDisplay();
    }
        
    public void RefreshDisplay()
    {    
        for (int i = 0; i < ProgressSegments.Length; i++)
            ProgressSegments[i].uiObject.SetActive(ProgressSegments[i].found);
    }
    
    public void CheckFoundStatus()
    {
        var allFound = true;
    
        foreach (var segment in ProgressSegments)
            if (!segment.found)
                allFound = false;
                
        if (allFound) OnAllFound.Invoke();
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
