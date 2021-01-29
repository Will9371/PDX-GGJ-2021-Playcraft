using UnityEngine;
using UnityEngine.UI;

public class DisplayPercentText : MonoBehaviour
{
    [SerializeField] Text text;
    public void Input(float value) { text.text = (value * 100).ToString("F0") + "%"; }
}
