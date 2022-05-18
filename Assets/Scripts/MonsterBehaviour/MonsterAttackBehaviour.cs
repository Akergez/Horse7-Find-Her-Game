using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class MonsterAttackBehaviour : MonoBehaviour
{
    public MonsterParameters monsterParameters;
    
    private int BasicDamage => monsterParameters.basicDamage;
    private double AttackRadius => monsterParameters.attackRadius;

    private bool _coroutineStarted;
    public double attackReadyness;

    public void Start()
    {
        monsterParameters = GetComponent<MonsterParameters>();
    }

    public void FixedUpdate()
    {
        var a = 0;
        if (!(BigData.Player == null || _coroutineStarted))
            StartCoroutine(AttackCoroutine());
        _coroutineStarted = true;
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if (Math.Abs(attackReadyness - 5) < 1e-9)
            {
                if (HelpMethods.IsNear(BigData.Player.playerBody, transform, AttackRadius))
                {
                    BigData.Player.GetDamage(BasicDamage);
                }

                attackReadyness = 0;
            }

            attackReadyness += 0.1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}