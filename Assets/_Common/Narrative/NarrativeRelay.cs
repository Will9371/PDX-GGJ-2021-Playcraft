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

    public void Refresh()

    {
        NarrativeManager.RefreshDisplay();
    }

    public void FindSegment(NarrativeSegment segment)
    {
        NarrativeManager.FindSegment(segment);
    }
}
