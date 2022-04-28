using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTable : MonoBehaviour
{
    public GameObject popTable;
    public GameObject popNote;
    public GameObject afterNote;
    public static bool isPopupTable;
    public static bool isPopupNote;
    public Collision2D collision;

    void Update()
    {
        
    }

    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player"))
        {
            collision = newCollision;
            Debug.Log("Popup Table");
            if (isPopupTable) Resume();
            else ShowPopupTable();
        }
        
    }

    public void Resume()
    {
        isPopupTable = false;
        ///Time.timeScale = 1f;
        popTable.SetActive(isPopupTable);
    }
    
    public void ResumeNote()
    {
        isPopupNote = false;
        Time.timeScale = 1f;
        popNote.SetActive(isPopupNote);
    }

    public void ShowPopupTable()
    {
        isPopupTable = true;
        ///Time.timeScale = 0f;
        popTable.SetActive(isPopupTable);
    }
    
    public void ShowPopupNote()
    {
        isPopupNote = true;
        Time.timeScale = 0f;
        popNote.SetActive(isPopupNote);
    }

    public void PressYes()
    {
        ShowPopupNote();
        Resume();
    }

    public void PressNo()
    {
        Resume();
    }

    public void PressNoNote()
    {
        ResumeNote();
        afterNote.SetActive(true);
    }
    public void PressNoAfter()
    {
        afterNote.SetActive(false);
    }

    void FixedUpdate()
    {
        if (collision != null && collision.contactCount == 0)
        {
            collision = null;
            Resume();
        }
    }
}
