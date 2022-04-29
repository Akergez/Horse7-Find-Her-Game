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
    public int Increment = 4;

    public void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        if (BigData.Player == null)
            BigData.Player = new Player(this);
        BigData.Player.PlayerBehaviour = this;
        Player = BigData.Player;
        StartCoroutine(HungerRecalculateCoroutine());
        StartCoroutine(AttackCoroutine());
    }

    public void OnDestroy()
    {
        StopCoroutine(HungerRecalculateCoroutine());
        StopCoroutine(AttackCoroutine());
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
            var secondIncrement = 0;
            while (!Input.GetKey(KeyCode.Space))
            {
                if(Increment == 4)
                    yield return new WaitForSeconds(0.005f);
                else
                {
                    secondIncrement++;
                    if (secondIncrement == 20)
                    {
                        Increment++;
                        secondIncrement = 0;
                    }

                    yield return new WaitForSeconds(0.005f);
                }
            }

            foreach (var monster in BigData.MonstersMap.Where(x =>
                         HelpMethods.IsNear(x.Key.transform, transform, 3))) //ToDo разхардкорить
            {
                var damageCoef = (Increment * 0.25 * 20);
                monster.Value.GetDamage(damageCoef);
                Increment = 0;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator HungerRecalculateCoroutine()
    {
        while (true)
        {
            Player.RecalculateHunger();
            yield return new WaitForSeconds(2); //ToDo расхардкорить
        }
    }
}