using UnityEngine;
using UnityEngine.UI;

public class DisplayItemUI : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text description;

    public void Initialize(NarrativeSegment data)
    {
        title.text = data.title;
        description.text = data.description;
    }
    
    public void SetActive(bool value) { gameObject.SetActive(value); }
}
