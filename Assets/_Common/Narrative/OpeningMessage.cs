using Playcraft.Dialog;
using UnityEngine;

public class OpeningMessage : MonoBehaviour
{
    [SerializeField] TypewriterText typewriter;
    [SerializeField] string[] lines;

    void Start() { GenerateMessage(); }
    
    void GenerateMessage()
    {
        var message = "";
    
        for (int i = 0; i < lines.Length; i++)
        {
            message += lines[i];
            
            if (i < lines.Length - 1)
                message += "\n";
        }
        
        typewriter.Input(message);
    }
}
