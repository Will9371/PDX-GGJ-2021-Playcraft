using UnityEngine;

public class SetActiveDrone : MonoBehaviour
{
    [SerializeField] GameObject selectionPanel;
    [SerializeField] SetDroneActive[] drones;
    [SerializeField] int startingIndex;
    
    void Start()
    {
        index = startingIndex;
        SetActiveDroneByIndex();
    }
    
    public int index;
    public void SetIndex(int value) 
    { 
        index = value;
        ToggleSelectionMode();
    }
    
    public void ToggleSelectionMode() { SetSelectionMode(!inSelectionMode); }
    
    bool inSelectionMode;
    public void SetSelectionMode(bool value)
    {
        inSelectionMode = value;
        selectionPanel.SetActive(value);
        
        if (value) DeactivateAll();
        else SetActiveDroneByIndex();
    }
    
    void SetActiveDroneByIndex()
    {
        for (int i = 0; i < drones.Length; i++)
            drones[i].SetActive(i == index);
    }
    
    void DeactivateAll()
    {
        for (int i = 0; i < drones.Length; i++)
            drones[i].SetActive(false);
    }
}
