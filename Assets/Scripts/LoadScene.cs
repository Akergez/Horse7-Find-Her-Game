using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LoadScene : MonoBehaviour
{
    public GameObject popCenter;
    public GameObject popLabirint;
    public Collision2D collision;
    [SerializeField]
    public string SceneToLoad;



    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player"))
        {
            collision = newCollision;
            Debug.Log("!");
            ShowPopupCenter();
        }
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        popCenter.SetActive(false);
    }
    
    public void ShowPopupCenter()
    {
        Time.timeScale = 0f;
        popCenter.SetActive(true);
    }
    
    public void PressYesLabirint()
    {
        SceneManager.LoadScene("Maze");
        Resume();
    }
    public void PressYes()
    {
        SceneManager.LoadScene(SceneToLoad);
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
