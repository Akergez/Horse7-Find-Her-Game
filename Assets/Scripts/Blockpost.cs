using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blockpost : MonoBehaviour
{
    public GameObject StartPopup;
    public List<GameObject> Dialogues;
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
        Dialogues.FirstOrDefault(x => x.activeSelf)?.SetActive(false);

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

    public void PressNext(int index)
    {
        Resume();
        Dialogues[index].SetActive(true);
    }
    public void Cancel()
    {
        ResumeSummary();
        Destroy(Object);
    } 
}
