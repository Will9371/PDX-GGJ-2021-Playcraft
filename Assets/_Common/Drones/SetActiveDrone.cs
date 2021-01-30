using System;
using UnityEngine;

public class SetActiveDrone : MonoBehaviour
{
    [SerializeField] GameObject selectionPanel;
    [SerializeField] DroneActivation[] droneData;
    [SerializeField] int startingIndex;
    
    void Start()
    {
        index = startingIndex;
        SetActiveDroneByIndex();
    }
    
    int index;
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
        for (int i = 0; i < droneData.Length; i++)
            droneData[i].drone.SetActive(i == index);
    }
    
    void DeactivateAll()
    {
        for (int i = 0; i < droneData.Length; i++)
            droneData[i].drone.SetActive(false);
    }
    
    [Serializable] public struct DroneActivation
    {
        public SetDroneActive drone;
        public GameObject droneUI;
    }
}
