using Playcraft;
using UnityEngine;

// TBD: extend for other data types
public class DowncastSO : MonoBehaviour
{
    [SerializeField] FloatEvent OutputFloat;
    
    public void Input(SO value)
    {
        if (value is FloatSO data)
            OutputFloat.Invoke(data.value);
    }
}
