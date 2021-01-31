using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Playcraft.Dialog
{
    public class TypewriterText : MonoBehaviour
    {
        #pragma warning disable 0649
        [SerializeField] Text text;
        [SerializeField] UnityEvent OnComplete;
        [Tooltip("In characters per second")]
        [SerializeField] float speed = 10;
        #pragma warning restore 0649
        
        string message;

        public void Input(string value)
        {
            message = value;
            StartCoroutine(TypeText());
        }
        
        IEnumerator TypeText()
        {
            text.text = "";

            foreach (var character in message)
            {
                text.text += character;
                yield return new WaitForSeconds(1/speed);
            }
            
            OnComplete.Invoke();
        }
        
        public void Skip()
        {
            StopAllCoroutines();
            text.text = message;
            OnComplete.Invoke();
        }
    }
}
