using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    public static int BasicDamage = 20;
    public static Transform Monster;
    bool coroutineStarted;

    public void Start()
    {
        Monster = GetComponent<Transform>();
    }

    public void Update()
    {
        if (BigData.Player != null && !coroutineStarted)
        {
            StartCoroutine(AttackCoroutine());
            coroutineStarted = true;
        }
    }

    private static IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if ((BigData.Player.PlayerBehaviour.transform.position - Monster.position).Length() < 1)
            {
                BigData.Player.GetDamage(BasicDamage);
            }

            yield return new WaitForSeconds(5);
        }
    }
}