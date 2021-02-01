using UnityEngine;

public class DisplayNarrative : MonoBehaviour
{
    [SerializeField] NarrativeManager narrative;
    [SerializeField] string emptyText;
    [SerializeField] StringEvent Output;

    public void Process()
    {
        Output.Invoke(narrative.DialogMessage);  
    }
}
