using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeLever : MonoBehaviour
{
    public GameObject leverOn;
    public GameObject leverOff;
    public bool isOff;
    public bool isPopup;
    public GameObject popup;

    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (!isPopup && newCollision.gameObject.CompareTag("Player"))
        {
            isPopup = true;
            popup.SetActive(isPopup);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPopup && !isOff)
        {
            Destroy(popup);
            isPopup = false;
            SwitchLever();
        }
    }

    private void SwitchLever()
    {
        leverOn.SetActive(isOff);
        isOff = true;
        leverOff.SetActive(isOff);
    }
}
