using UnityEngine;
using UnityEngine.UI;

// Edit the color on multiple UI elements at once
public class SyncColor : MonoBehaviour
{
    [SerializeField] Color color;
    [SerializeField] Text[] textElements;
    [SerializeField] Image[] imageElements;
    
    void OnValidate()
    {
        foreach (var text in textElements)
            text.color = color;
        foreach (var image in imageElements)
            image.color = color;
    }
}
