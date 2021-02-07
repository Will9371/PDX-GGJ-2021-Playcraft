using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogManager : MonoBehaviour
{
    public Toggle ExplorationQuestToggle;
    public Text ExplorationQuestText;
    public int ExplorationQuestGoal;
    public Toggle AirlockQuestToggle;

    public void UpdateQuestProgress(int progress)
    {
        ExplorationQuestText.text = string.Format("Investigate station\n({0} / {1})", Mathf.Min(progress, ExplorationQuestGoal), ExplorationQuestGoal);
        ExplorationQuestToggle.isOn = progress >= ExplorationQuestGoal;
    }

    public void SetAirlockQuestComplete()
    {
        AirlockQuestToggle.isOn = true;
    }
}
