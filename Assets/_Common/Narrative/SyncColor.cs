using UnityEngine;
using UnityEngine.UI;

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
