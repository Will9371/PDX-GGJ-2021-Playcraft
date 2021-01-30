using UnityEngine;
using Playcraft;

public class DisplayNarrative : MonoBehaviour
{
    [SerializeField] NarrativeManager narrative;
    [SerializeField] string emptyText;
    [SerializeField] StringEvent Output;

    public void Process()
    {
        var rawData = narrative.GetFoundText();
        var result = "";
        
        for (int i = 0; i < rawData.Length; i++)
        {
            result += rawData[i] == "" ? emptyText : rawData[i];
            if (i < rawData.Length - 1) result += "\n";
        }
        
        Output.Invoke(result);  
    }
}
