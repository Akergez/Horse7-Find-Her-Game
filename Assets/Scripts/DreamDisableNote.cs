using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamDisableNote : MonoBehaviour
{
    public GameObject popTable;
    public static bool isPopupTable;
    public Collision2D collision;
    int visitCount;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player") && visitCount == 0)
        {
            collision = newCollision;
            Debug.Log("Popup Table");
            if (isPopupTable) Resume();
            else
            {
                visitCount += 1;
                ShowPopupTable();
            }
        }
    }
    
    public void Resume()
    {
        isPopupTable = false;
        ///Time.timeScale = 1f;
        popTable.SetActive(isPopupTable);
    }

    public void ShowPopupTable()
    {
        isPopupTable = true;
        ///Time.timeScale = 0f;
        popTable.SetActive(isPopupTable);
    }

    public void PressNo()
    {
        Resume();
    }
}
