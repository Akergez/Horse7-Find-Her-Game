using System.Collections;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Player Player;
    public bool isMoving;
    public void Start()
    {
        Player = new Player();
        StartCoroutine(HungerRecalculateCoroutine());
    }

    public void Update()
    {
        var playerMovement = (PlayerMovement) FindObjectOfType(typeof(PlayerMovement));
        if (Player.HealtPoints == 0)
            Destroy(playerMovement.spriteRenderer);
    }

    private IEnumerator HungerRecalculateCoroutine()
    {
        while (true)
        {
            Player.RecalculateHunger();
            if (isMoving)
            {
                Player.RecalculateHunger();
                isMoving = false;
            }
            yield return new WaitForSeconds(2);
        }
    }
}