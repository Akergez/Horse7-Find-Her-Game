using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeLever : MonoBehaviour
{
    public static int leverCount;
    public static bool isPopupDestroyed;
    public GameObject leverOn;
    public GameObject leverOff;
    public bool isUsed;
    public bool isPopup;
    public GameObject popup;
    
    [SerializeField]
    Transform player;

    [SerializeField]
    float distance;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (!isPopup && newCollision.gameObject.CompareTag("Player") && !isPopupDestroyed)
        {
            isPopup = true;
            popup.SetActive(isPopup);
        }
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer > distance)
        {
            isPopup = false;
            popup.SetActive(isPopup);
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.E) && !isUsed)
        {
            isPopupDestroyed = true;
            isPopup = false;
            popup.SetActive(isPopup);
            leverCount++;
            SwitchLever();
            isUsed = true;
        }
    }

    private void SwitchLever()
    {
        leverOn.SetActive(false);
        leverOff.SetActive(true);
    }
}