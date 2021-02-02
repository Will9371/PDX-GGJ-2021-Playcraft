using UnityEngine;
using Playcraft;

[CreateAssetMenu(menuName = "Game Jam/Narrative Segment")]
public class NarrativeSegment : SO
{
    public int index;
    public Sprite sprite;
    public AudioClip vo;
    public string title;
    public string description;
}
