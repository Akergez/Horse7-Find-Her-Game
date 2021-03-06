using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.DialoguesBehaviour;
using UnityEngine;

public class MazeLever : MonoBehaviour
{
    public GameObject leverOn;
    public GameObject leverOff;
    public bool isUsed;
    public SimplePopUpShow PopUpShow;
    public static bool popUpShown;
    

    public bool isOff = true;

    private void Start()
    {
        PopUpShow = GetComponent<SimplePopUpShow>();
    }

    void Update()
    {
        if(popUpShown)
            PopUpShow.DestroyPopUp();
        if (Input.GetKeyDown(KeyCode.E) && !isUsed && PopUpShow.isPopup)
        {
            PopUpShow.isPopupDestroyed = true;
            SwitchLever();
            isUsed = true;
            popUpShown = true;
            PopUpShow.DestroyPopUp();
        }
    }

    private void SwitchLever()
    {
        leverOn.SetActive(false);
        leverOff.SetActive(true);
        isOff = false;
    }
}