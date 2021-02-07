using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogManager : MonoBehaviour
{
    public Toggle ExplorationQuestToggle;
    public Text ExplorationQuestText;
    public Toggle AirlockQuestToggle;

    public void UpdateQuestProgress(int progress, int goal)
    {
        ExplorationQuestText.text = string.Format("Investigate station\n({0} / {1})", Mathf.Min(progress, goal), goal);
        ExplorationQuestToggle.isOn = progress >= goal;
    }

    public void SetAirlockQuestComplete()
    {
        AirlockQuestToggle.isOn = true;
    }
}
