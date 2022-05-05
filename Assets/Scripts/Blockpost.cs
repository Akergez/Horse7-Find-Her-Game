using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockpost : MonoBehaviour
{
    public GameObject StartPopup;
    public GameObject Dialogue1;
    public GameObject Dialogue2;
    public GameObject Dialogue3;
    public GameObject Dialogue4;
    public GameObject Dialogue5;
    public GameObject Summary;
    public GameObject Object;
    public Collision2D collision;
    public static bool isPopupDialog;
    int visitCount;
    
    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player") && visitCount == 0)
        {
            collision = newCollision;
            Debug.Log("Popup Dialog");
            if (isPopupDialog) Resume();
            else
            {
                visitCount += 1;
                ShowPopupStart();
            }
        }
    }

    public void Resume()
    {
        ///isPopupDialog = false;
        ///Time.timeScale = 1f;
        StartPopup.SetActive(false);
    }
    public void ResumeD1()
    {
        Dialogue1.SetActive(false);
    }
    public void ResumeD2()
    {
        Dialogue2.SetActive(false);
    }
    public void ResumeD3()
    {
        Dialogue3.SetActive(false);
    }
    public void ResumeD4()
    {
        Dialogue4.SetActive(false);
    }
    public void ResumeD5()
    {
        Dialogue5.SetActive(false);
    }
    public void ResumeSummary()
    {
        isPopupDialog = false;
        Summary.SetActive(false);
    }

    public void ShowPopupStart()
    {
        isPopupDialog = true;
        StartPopup.SetActive(isPopupDialog);
    }

    public void PressNext1()
    {
        Resume();
        Dialogue1.SetActive(true);
    }
    public void PressNext2()
    {
        ResumeD1();
        Dialogue2.SetActive(true);
    }
    public void PressNext3()
    {
        ResumeD2();
        Dialogue3.SetActive(true);
    }
    public void PressNext4()
    {
        ResumeD3();
        Dialogue4.SetActive(true);
    }
    public void PressNext5()
    {
        ResumeD4();
        Dialogue5.SetActive(true);
    }
    public void PressNext6()
    {
        ResumeD5();
        Summary.SetActive(true);
    }
    public void Cancel()
    {
        ResumeSummary();
        Destroy(Object);
    } 
}
