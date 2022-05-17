using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Classes;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class MonsterBehaviour : MonoBehaviour
{
    private DirectionFinder _directionFinder;
    public static int BasicDamage = 20;
    public Transform Transform;
    private bool _coroutineStarted;
    public static Monster Monster;

    [FormerlySerializedAs("MonsterBody")] [SerializeField]
    public GameObject monsterBody;

    [FormerlySerializedAs("AttackRadius")] [SerializeField]
    public double attackRadius;

    public double attackReadyness;

    public NavMeshAgent nmAgent;
    [SerializeField] public List<Transform> PatrolPoints;
    public int PatrolingIndex;

    [SerializeField] public float PatrolingDistance;
    [SerializeField] public float PlayerVisibilityDistance;
    [SerializeField] public int PlayerVisibilityAngle;

    [SerializeField] public double DistanceToPoint;

    [SerializeField] public LayerMask playerMask;
    [SerializeField] public LayerMask wallsMask;

    public void Start()
    {
        _directionFinder = GetComponent<DirectionFinder>();
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

    public void FixedUpdate()
    {
        DistanceToPoint = (transform.position - PatrolPoints[PatrolingIndex].position).Length();
        //nmAgent.SetDestination();
        if (HelpMethods.IsNear(transform, PatrolPoints[PatrolingIndex],
                PatrolingDistance)) //ToDo пофиксить индекс, выходит за массив
            if (PatrolingIndex + 1 < PatrolPoints.Count)
                PatrolingIndex++;
            else
                PatrolingIndex = 0; //= HelpMethods.GetRandomIndex(0, PatrolPoints.Count - 1);
        nmAgent.SetDestination(PatrolPoints[PatrolingIndex].position);
        if (IsPlayerVisible())
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
    {
        /*
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

    public bool IsPlayerVisible()
    {
        var nearColliders = Physics2D.OverlapCircleAll(transform.position, PlayerVisibilityDistance, playerMask);
        var Colliders = Physics2D.OverlapCircleAll(transform.position, PlayerVisibilityDistance, wallsMask);
        var IsObstacleBetweenPlayerAndMonster = true;
        if (nearColliders.Length != 0)
        {
            var distance = (nearColliders[0].transform.position - transform.position).Length();
            var target = nearColliders[0].transform;
            var position = transform.position;
            var directionToTarget = (target.position - position).normalized;
            IsObstacleBetweenPlayerAndMonster = Physics2D.Raycast(position, directionToTarget, (float)distance, wallsMask);
        }
        var playerPosition = BigData.Player.PlayerBehaviour.transform.position;
        return HelpMethods.IsNear(BigData.Player.PlayerBehaviour.transform, transform, PlayerVisibilityDistance)
               && _directionFinder.MovementVector.GetAngle(playerPosition - transform.position) <
               PlayerVisibilityAngle / 2
               && !IsObstacleBetweenPlayerAndMonster;
    }
}