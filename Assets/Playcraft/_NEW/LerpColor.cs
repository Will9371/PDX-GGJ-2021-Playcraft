using UnityEngine;

public class LerpColor : MonoBehaviour
{
    [SerializeField] Color startColor;
    [SerializeField] Color endColor;
    [SerializeField] ColorEvent Output;

    public void Input(float percent) { Output.Invoke(Color.Lerp(startColor, endColor, percent)); }
}
