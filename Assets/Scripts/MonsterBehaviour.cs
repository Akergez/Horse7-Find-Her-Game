using System;
using System.Collections;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    public static int BasicDamage = 20;
    public static PlayerBehaviour PlayerBehaviourr;
    public static Transform Monster;
    bool coroutineStarted = false;

    public void Start()
    {
        PlayerBehaviourr = FindObjectOfType<PlayerBehaviour>();
        Monster = GetComponent<Transform>();
    }

    public void Update()
    {
        if (PlayerBehaviourr.Player != null && !coroutineStarted)
        {
            StartCoroutine(AttackCoroutine());
            coroutineStarted = true;
        }
    }

    private static IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if ((PlayerBehaviourr.Transform.position - Monster.position).Length() < 1)
            {
                PlayerBehaviourr.Player.BeAttacked(BasicDamage);
            }

            yield return new WaitForSeconds(5);
        }
    }
}