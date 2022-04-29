using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupCafe : MonoBehaviour
{
    public static bool isPopupMenu;
    public GameObject popMenu;
    public GameObject coins;
    public GameObject noCoins;
    public Collision2D collision;
    int visitCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player") && visitCount == 0)
        {
            collision = newCollision;
            Debug.Log("Popup Table");
            if (isPopupMenu) Resume();
            else
            {
                visitCount += 1;
                ShowPopupMenu();
            }
            
        }
        
    }
    public void Resume()
    {
        isPopupMenu = false;
        Time.timeScale = 1f;
        popMenu.SetActive(isPopupMenu);
    }

    public void ShowPopupMenu()
    {
        isPopupMenu = true;
        Time.timeScale = 0f;
        popMenu.SetActive(isPopupMenu);
    }

    public void PressNo()
    {
        Resume();
        Destroy(popMenu);
    }

    public void PressYes()
    {
        coins.SetActive(false);
        noCoins.SetActive(true);
        
        Destroy(popMenu);
        Time.timeScale = 1f;
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
