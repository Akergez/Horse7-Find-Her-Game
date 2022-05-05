using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupSister : MonoBehaviour
{
    public GameObject popSister;
    public static bool isPopupSister;
    public Collision2D collision;
    int visitCount;

    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player") && visitCount == 0)
        {
            collision = newCollision;
            Debug.Log("Popup Sister");
            if (isPopupSister) Resume();
            else
            {
                visitCount += 1;
                ShowPopupSister();
            }
        }
    }

    public void Resume()
    {
        isPopupSister = false;
        ///Time.timeScale = 1f;
        popSister.SetActive(isPopupSister);
    }

    public void ShowPopupSister()
    {
        isPopupSister = true;
        ///Time.timeScale = 0f;
        popSister.SetActive(isPopupSister);
    }

    public void Press()
    {
        SceneManager.LoadScene("SampleScene");
        Resume();
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
