using System;
using System.Collections;
using Classes;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class MonsterBehaviour : MonoBehaviour
{
    public static int BasicDamage = 20;
    public Transform Transform;
    private bool _coroutineStarted;
    public static Monster Monster;
    [FormerlySerializedAs("MonsterBody")] [SerializeField] public GameObject monsterBody;

    [FormerlySerializedAs("AttackRadius")] [SerializeField] public double attackRadius;

    public double attackReadyness;

    public NavMeshAgent nmAgent;

    public void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        nmAgent.updateRotation = false;
        nmAgent.updateUpAxis = false;
        GetComponent<SpriteRenderer>();
        Transform = GetComponent<Transform>();
        Monster = new Monster(this);
        BigData.MonstersMap[this] = Monster;
    }

    public void OnDestroy()
    {
        BigData.MonstersMap.Remove(this);
        Destroy(monsterBody);
    }

    public void Update()
    {
        nmAgent.SetDestination(BigData.Player.PlayerBehaviour.transform.position);
        if (!(BigData.Player == null || _coroutineStarted))
            StartCoroutine(AttackCoroutine());
        if (!BigData.MonstersMap[this].IsAlive)
        {
            Destroy(this);
        }

        _coroutineStarted = true;
    }

    public void HandleDamage()
    {/*
        var position = Transform.position;
        var vector = position - BigData.Player.PlayerBehaviour.transform.position;
        position += vector.normalized * 0.3f;
        Transform.position = position;*/
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