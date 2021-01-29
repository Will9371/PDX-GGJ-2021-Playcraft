using UnityEngine;
using UnityEngine.UI;

public class DisplayNarrative : MonoBehaviour
{
    [SerializeField] NarrativeManager narrative;
    [SerializeField] Text text;
    [SerializeField] string emptyText;


    void OnEnable()
    {
        var rawData = narrative.GetFoundText();
        text.text = "";
        
        foreach (var item in rawData)
        {
            text.text += item == "" ? emptyText : item;
            text.text += "\n";
        }        
    }
}
