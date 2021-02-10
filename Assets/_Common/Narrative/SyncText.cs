using UnityEngine;
using UnityEngine.UI;

public class SyncText : MonoBehaviour
{
    [SerializeField] int fontSize;
    [SerializeField] Text[] syncedText;

    void OnValidate()
    {
        foreach (var text in syncedText)
        {
            text.fontSize = fontSize;
        }
    }
}
