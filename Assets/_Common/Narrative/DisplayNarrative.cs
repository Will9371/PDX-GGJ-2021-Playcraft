using UnityEngine;
using UnityEngine.UI;

public class DisplayNarrative : MonoBehaviour
{
    [SerializeField] NarrativeManager narrative;
    [SerializeField] Image image;
    [SerializeField] AudioSource voSource;
    [SerializeField] string emptyText;
    [SerializeField] StringEvent Output;

    public void Process()
    {
        Output.Invoke(narrative.DialogMessage);
        if (narrative.DialogVO != null)
        {
            voSource.clip = narrative.DialogVO;
            voSource.Play();
        }
        image.sprite = narrative.DialogSprite;
        image.color = image.sprite == null ? Color.clear : Color.white;
    }
}
