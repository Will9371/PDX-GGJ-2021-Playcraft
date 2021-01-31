using System;
using UnityEngine;

public class SetActiveDrone : MonoBehaviour
{
    [SerializeField] GameObject selectionPanel;
    public DroneActivation[] droneData;
    [SerializeField] int startingIndex;
    
    //DroneState currentDroneState => droneData[index].drone.state;
    //bool canChange => currentDroneState.docked || currentDroneState.dead;
    
    void Start()
    {
        index = startingIndex;
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
        //if (value && !canChange)
        //    return;
                
        inSelectionMode = value;
        selectionPanel.SetActive(value);
        if (value) DisplayDockedDrones();
        
        if (value) DeactivateAll();
        else SetActiveDroneByIndex();
    }
    
    public void SetActiveDroneByIndex()
    {
        for (int i = 0; i < droneData.Length; i++)
            droneData[i].drone.SetActive(i == index);
    }
    
    void DeactivateAll()
    {
        for (int i = 0; i < droneData.Length; i++)
            droneData[i].drone.SetActive(false);
    }
    
    void DisplayDockedDrones()
    {
        for (int i = 0; i < droneData.Length; i++)
        {
            var state = droneData[i].drone.state;
            droneData[i].droneUI.SetActive(state.docked || state.active);
        }
    }
    
    [Serializable] public struct DroneActivation
    {
        public SetDroneActive drone;
        public GameObject droneUI;
    }
}
