using UnityEngine;

public class popupCafe : MonoBehaviour
{
    public static bool isPopupMenu;
    public GameObject popMenu;
    public Collision2D collision;
    int visitCount;

    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player"))
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
        popMenu.SetActive(false);
        isPopupMenu = false;
    }

    public void PressYes()
    {
        if(collision.gameObject.GetComponent<PlayerParameters>().IncreaseMoney(-5))
            collision.gameObject.GetComponent<PlayerParameters>().IncreaseFood(1);

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
