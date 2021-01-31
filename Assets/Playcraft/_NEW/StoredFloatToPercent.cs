using UnityEngine;

public class StoredFloatToPercent : MonoBehaviour
{
    public Vector2 range;
    [SerializeField] FloatEvent Percent;
    [SerializeField] bool startAtMaximum;
    
    float storage;
    [HideInInspector] public float percent;
    
    void Start()
    {
        if (startAtMaximum)
            Set(range.y);
    }
    
    public void AddOverTime(float value) { Add(value * Time.deltaTime); }
    
    public void Add(float value) 
    { 
        storage += value;
        Set(Mathf.Clamp(storage, range.x, range.y));
    }
    
    void Set(float value)
    {
        storage = value;
        percent = (storage - range.x) / (range.y - range.x);
        Percent.Invoke(percent);
    }
}
