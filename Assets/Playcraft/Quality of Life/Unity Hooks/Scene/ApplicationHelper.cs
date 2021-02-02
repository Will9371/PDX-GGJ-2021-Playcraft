using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Playcraft
{
    public class ApplicationHelper : MonoBehaviour
    {
        [SerializeField] UnityEvent OnQuit;

        List<RuntimePlatform> StandalonePlatforms = new List<RuntimePlatform>
        {
            RuntimePlatform.LinuxPlayer,
            RuntimePlatform.WindowsPlayer,
            RuntimePlatform.OSXPlayer,
        };

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            if (StandalonePlatforms.Contains(Application.platform)
            {
                Application.Quit();
            }
#endif
        }

        public void OnApplicationQuit()
        {
            OnQuit.Invoke();    
        }
    }
}