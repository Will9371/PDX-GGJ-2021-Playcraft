using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPanel : MonoBehaviour
{
    public WallPanelType panelType = WallPanelType.Blank;
    public enum WallPanelType {
        Blank,
        Flat,
        Cargo,
        Science,
        LifeSupport,
        Multi
    }

    // Start is called before the first frame update
    void Start()
    {
        //editor script instead?
        
        // Select wall mesh based on panelType
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
