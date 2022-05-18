using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class MonsterAttackBehaviour : EnemyAttackBehaviour
{
    private int BasicDamage => monsterParameters.basicDamage;
    private float _attackCD => monsterParameters.AttackCD;

    private bool _coroutineStarted;
    public double attackReadyness;

    public void FixedUpdate()
    {
        if (!(monsterParameters.playerBody == null || _coroutineStarted))
            StartCoroutine(AttackCoroutine());
        _coroutineStarted = true;
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if (Math.Abs(attackReadyness - 5) < 1e-9)
            {
                if (HelpMethods.IsNear(monsterParameters.playerBody.playerBody, transform, AttackRadius))
                {
                    monsterParameters.playerBody.GetDamage(BasicDamage);
                }

                attackReadyness = 0;
            }

            attackReadyness += 0.1;
            yield return new WaitForSeconds(_attackCD/50);
        }
    }
}