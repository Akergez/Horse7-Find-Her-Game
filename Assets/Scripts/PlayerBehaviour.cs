using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class PlayerBehaviour : MonoBehaviour
{
    public Player Player;
    public PlayerMovement playerMovement;
    public Rigidbody2D rigidbody2D;

    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Player = new Player();
        StartCoroutine(HungerRecalculateCoroutine());
    }

    public void Update()
    {
        playerMovement = (PlayerMovement) FindObjectOfType(typeof(PlayerMovement));
        if (Player.HealtPoints == 0)
            Destroy(playerMovement.spriteRenderer);
    }

    private IEnumerator HungerRecalculateCoroutine()
    {
        var rnd = new Random();
        while (true)
        {
            if(rnd.Next()%5==0)
                Player.RecalculateHunger();
            if (rigidbody2D.velocity!=Vector2.zero)
            {
                Player.RecalculateHunger();
            }

            yield return new WaitForSeconds(rnd.Next());
        }
    }
}