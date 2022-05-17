using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Classes;
using DefaultNamespace;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class MonsterAttackBehaviour : MonoBehaviour
{
    public MonsterParameters MonsterParameters;
    private DirectionFinder _directionFinder;
    public int BasicDamage => MonsterParameters.basicDamage;
    private bool _coroutineStarted;

    public double attackRadius => MonsterParameters.attackRadius;
    public double attackReadyness;

    public void Start()
    {
        MonsterParameters = GetComponent<MonsterParameters>();
    }

    public void FixedUpdate()
    {
        if (!(BigData.Player == null || _coroutineStarted))
            StartCoroutine(AttackCoroutine());
        _coroutineStarted = true;
    }

    public void HandleDamage()
    {
        _directionFinder.MovementVector = -_directionFinder.MovementVector;
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if (Math.Abs(attackReadyness - 5) < 1e-9)
            {
                if (HelpMethods.IsNear(BigData.Player.PlayerBehaviour.transform, transform, attackRadius))
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