using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject popCenter;
    public static bool isPopupCenter;
    public Collision2D collision;



    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player"))
        {
            collision = newCollision;
            Debug.Log("!");
            if (isPopupCenter) Resume();
            else ShowPopupCenter();
        }
        
    }

    public void Resume()
    {
        isPopupCenter = false;
        Time.timeScale = 1f;
        popCenter.SetActive(isPopupCenter);
    }
    
    public void ShowPopupCenter()
    {
        isPopupCenter = true;
        Time.timeScale = 0f;
        popCenter.SetActive(isPopupCenter);
    }
    

    public void PressYes()
    {
        
        SceneManager.LoadScene("center");
        Resume();
    }
    public void PressYesCenter()
    {
        
        SceneManager.LoadScene("SampleScene");
        Resume();
    }

    public void PressNoCenter()
    {
        
        Resume();
    }

    public void PressNo()
    {
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
