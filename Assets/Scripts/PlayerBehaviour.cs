using System;
using System.Collections;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class PlayerBehaviour : MonoBehaviour
{
    public Player Player;
    public PlayerMovement playerMovement;
    public Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = new Player(this);
        BigData.Player = Player;
        StartCoroutine(HungerRecalculateCoroutine());
        StartCoroutine(AttackCoroutine());
    }

    public void Update()
    {
        playerMovement = (PlayerMovement) FindObjectOfType(typeof(PlayerMovement));
        ///if (Player.HealtPoints == 0)
        ///Destroy(playerMovement.spriteRenderer);
    }

    public IEnumerator AttackCoroutine()
    {
        while (true)
        {
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return null;
            }

            foreach (var monster in BigData.MonstersMap.Where(x =>
                         HelpMethods.IsNear(x.Key.transform, transform, 10)))
            {
                monster.Value.GetDamage(20); //ToDo расхардкорить
            }
        }
    }

    private IEnumerator HungerRecalculateCoroutine()
    {
        var rnd = new Random();
        while (true)
        {
            if (rnd.Next() % 5 == 0)
                Player.RecalculateHunger();
            if (rb.velocity != Vector2.zero)
            {
                Player.RecalculateHunger();
            }

            yield return new WaitForSeconds(rnd.Next());
        }
    }
}