using UnityEngine;

public class ActivateDroneUI : MonoBehaviour
{
    [SerializeField] GameObject selectButton;
    [SerializeField] GameObject warningMessage;
    
    public void SetActive(bool value)
    {
        selectButton.SetActive(value);
        warningMessage.SetActive(!value);
    }
}
