using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeRelay : MonoBehaviour
{
    public NarrativeManager NarrativeManager;

    public void Show(NarrativeSegment segment)
    {
        NarrativeManager.Show(segment);
    }

    public string[] GetFoundText()
    {
        return NarrativeManager.GetFoundText();
    }

    public void FindSegment(NarrativeSegment segment)
    {
        NarrativeManager.FindSegment(segment);
    }
}
