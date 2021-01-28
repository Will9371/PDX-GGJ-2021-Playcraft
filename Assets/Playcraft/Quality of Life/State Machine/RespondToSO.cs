using UnityEngine;

// MODIFIED
namespace Playcraft
{
    public class RespondToSO : MonoBehaviour
    {
        #pragma warning disable 0649
        [SerializeField] EventResponder responder;
        [SerializeField] bool locked;
        #pragma warning restore 0649
        
        public void SetLock(bool value) { locked = value; }

        public void Input(SO value)
        {
            if (locked) return;
            var response = responder.GetResponse(value);
            response?.Invoke(); 
        }
    }
}
