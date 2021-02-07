using Playcraft.Dialog;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField] SegmentData[] ProgressSegments;
    [SerializeField] GameObject DialogPanel;
    [SerializeField] GameObject ProgressPanel;
    public TypewriterText TypewriterText;
    public string DialogMessage;
    public Sprite DialogSprite;
    public AudioClip DialogVO;
    [SerializeField] UnityEvent OnAllFound;

    public Action<int, int> OnSegmentFound;
    public Action OnAirlockReached;

    public int InvestigationGoal;
    public NarrativeSegment ReadyToSolve;
    bool HasShownReadyToSolveMessage;

    [HideInInspector] public int InvestigationProgress;
    [HideInInspector] public bool HasReachedAirlock;

    List<NarrativeSegment> SegmentsSeen = new List<NarrativeSegment>();

    public void Show(NarrativeSegment segment)
    {
        DialogMessage = segment.description;
        DialogSprite = segment.sprite;
        DialogVO = segment.vo;
        if (!SegmentsSeen.Contains(segment))
        {
            SegmentsSeen.Add(segment);
            InvestigationProgress = SegmentsSeen.Count;
            OnSegmentFound?.Invoke(InvestigationProgress, InvestigationGoal);
        }
        DialogPanel.SetActive(true);
    }

    public bool QuestsComplete()
    {
        return InvestigationProgress >= InvestigationGoal && HasReachedAirlock;
    }

    public void ReachAirlock()
    {
        HasReachedAirlock = true;

        if (QuestsComplete() && !HasShownReadyToSolveMessage)
        {
            HasShownReadyToSolveMessage = true;
            Show(ReadyToSolve);
        }

        OnAirlockReached?.Invoke();
    }

    public void RefreshQuestProgress()
    {
        OnSegmentFound?.Invoke(InvestigationProgress, InvestigationGoal);
        if (HasReachedAirlock)
        {
            OnAirlockReached?.Invoke();
        }
    }

    public void TryDismiss()
    {
        if (TypewriterText.IsDone())
        {
            DialogPanel.SetActive(false);
            if (QuestsComplete() && !HasShownReadyToSolveMessage)
            {
                HasShownReadyToSolveMessage = true;
                Show(ReadyToSolve);
            }
        }
        else
        {
            TypewriterText.Skip();
        }
    }
    
    public void FindSegment(NarrativeSegment segment)
    {
        ProgressSegments[segment.index].found = true;
        CheckFoundStatus();
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
