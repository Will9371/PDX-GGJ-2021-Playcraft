using UnityEngine;

public class ToggleOverTime : MonoBehaviour
{
    [SerializeField] float startDelay = 0f;
    [SerializeField] float repeatRate = 0.5f;
    [SerializeField] BoolEvent Output;
    [SerializeField] bool activateWithEnabled;
    
    bool state;
    
    void OnEnable()
    {
        if (activateWithEnabled)
            SetActive(true);
    }
    
    void OnDisable()
    {
        if (activateWithEnabled)
            SetActive(false);
    }

    public void SetActive(bool value)
    {
        CancelInvoke(nameof(Toggle));
        if (value) InvokeRepeating(nameof(Toggle), startDelay, repeatRate);
    }
    
    void Toggle()
    {
        state = !state;
        Output.Invoke(state);
    }
}
