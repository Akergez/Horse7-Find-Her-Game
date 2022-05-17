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

public class MonsterNavigationBehaviour : MonoBehaviour
{
    public MonsterParameters MonsterParameters;

    private DirectionFinder _directionFinder;
    private bool _coroutineStarted;

    public NavMeshAgent nmAgent;
    [SerializeField] public List<Transform> PatrolPoints;
    public int PatrolingIndex;
    
    public float PatrolingDistance => MonsterParameters.PatrolingDistance;

    public float PlayerInFOVVisibilityDistance => MonsterParameters.PlayerInFOVVisibilityDistance;
    public int PlayerVisibilityAngle => MonsterParameters.PlayerVisibilityAngle;
    public float PlayerBackVisibilityAngle => MonsterParameters.PlayerBackVisibilityAngle;

    [SerializeField] public LayerMask playerMask;
    [SerializeField] public LayerMask wallsMask;

    public void Start()
    {
        MonsterParameters = GetComponent<MonsterParameters>();
        SetupNavMeshAgent();
    }

    private void SetupNavMeshAgent()
    {
        _directionFinder = GetComponent<DirectionFinder>();
        nmAgent = GetComponent<NavMeshAgent>();
        nmAgent.updateRotation = false;
        nmAgent.updateUpAxis = false;
    }

    public void FixedUpdate()
    {
        if (HelpMethods.IsNear(transform, PatrolPoints[PatrolingIndex],
                PatrolingDistance))
            if (PatrolingIndex + 1 < PatrolPoints.Count)
                PatrolingIndex++;
            else
                PatrolingIndex = 0;
        nmAgent.SetDestination(PatrolPoints[PatrolingIndex].position);
        if (IsPlayerVisible())
            nmAgent.SetDestination(BigData.Player.PlayerBehaviour.transform.position);
    }

    public bool IsPlayerVisible()
    {
        var nearColliders = Physics2D.OverlapCircleAll(transform.position, PlayerInFOVVisibilityDistance, playerMask);
        var IsObstacleBetweenPlayerAndMonster = true;
        if (nearColliders.Length != 0)
        {
            var distance = (nearColliders[0].transform.position - transform.position).Length();
            var target = nearColliders[0].transform;
            var position = transform.position;
            var directionToTarget = (target.position - position).normalized;
            IsObstacleBetweenPlayerAndMonster =
                Physics2D.Raycast(position, directionToTarget, (float) distance, wallsMask);
        }

        var playerPosition = BigData.Player.PlayerBehaviour.transform.position;
        return HelpMethods.IsNear(BigData.Player.PlayerBehaviour.transform, transform, PlayerInFOVVisibilityDistance)
               && _directionFinder.MovementVector.GetAngle(playerPosition - transform.position) <
               PlayerVisibilityAngle / 2
               && !IsObstacleBetweenPlayerAndMonster
               || HelpMethods.IsNear(BigData.Player.PlayerBehaviour.transform, transform, PlayerBackVisibilityAngle);
    }
}