using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamDisableNote : MonoBehaviour
{
    public GameObject popTable;
    private static bool _isPopupTable;

    private int _visitCount;

    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player") && _visitCount == 0)
        {
            Debug.Log("Popup Table");
            if (_isPopupTable) Resume();
            else
            {
                _visitCount += 1;
                ShowPopupTable();
            }
        }
    }

    private void Resume()
    {
        _isPopupTable = false;
        popTable.SetActive(_isPopupTable);
    }

    private void ShowPopupTable()
    {
        _isPopupTable = true;
        popTable.SetActive(_isPopupTable);
    }

    public void PressNo()
    {
        Resume();
    }
}