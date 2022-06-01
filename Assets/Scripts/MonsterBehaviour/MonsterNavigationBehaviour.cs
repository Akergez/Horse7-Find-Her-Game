using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class MonsterNavigationBehaviour : MonoBehaviour
{
    public MonsterParameters monsterParameters;
    private DirectionFinder _directionFinder;
    public NavMeshAgent nmAgent;

    private float PatrolingDistance => monsterParameters.patrolingDistance;
    private float PlayerInFOVVisibilityDistance => monsterParameters.playerInFOVVisibilityDistance;
    private int PlayerVisibilityAngle => monsterParameters.playerVisibilityAngle;
    private float PlayerBackVisibilityAngle => monsterParameters.playerBackVisibilityAngle;
    private Transform PlayerBody => monsterParameters.playerBody.playerBody;

    private float Stamina => monsterParameters.monsterStamiinaInSeconds;
    public bool isFollowing;

    [SerializeField] public List<Transform> patrolPoints;
    [SerializeField] public int patrolingIndex;
    [SerializeField] public LayerMask playerMask;
    [SerializeField] public LayerMask wallsMask;
    [SerializeField] public double distanceToTarget;

    public void Start()
    {
        monsterParameters = GetComponent<MonsterParameters>();
        SetupNavMeshAgent();
    }

    private void SetupNavMeshAgent()
    {
        _directionFinder = GetComponent<DirectionFinder>();
        nmAgent = GetComponent<NavMeshAgent>();
        nmAgent.updateRotation = false;
        nmAgent.updateUpAxis = false;
        nmAgent.speed = monsterParameters.navigationSpeed;

    }

    public void FixedUpdate()
    {
        var target = patrolPoints[patrolingIndex].position;
        if (HelpMethods.IsNear(transform, patrolPoints[patrolingIndex],
                PatrolingDistance))
            if (patrolingIndex + 1 < patrolPoints.Count)
                patrolingIndex++;
            else
                patrolingIndex = 0;
        target = patrolPoints[patrolingIndex].position;
        if (IsPlayerVisible())
        {
            nmAgent.SetDestination(PlayerBody.position);
            if (!isFollowing)
                StartCoroutine(SpeedIncreaseCoroutine());
            target = PlayerBody.position;
            isFollowing = true;
        }
        else
        {
            nmAgent.SetDestination(patrolPoints[patrolingIndex].position);
            isFollowing = false;
        }

        distanceToTarget = (monsterParameters.transform.position - target).Length();
    }

    public IEnumerator SpeedIncreaseCoroutine()
    {
        nmAgent.speed = monsterParameters.followingSpeed;
        yield return new WaitForSeconds(Stamina);
        nmAgent.speed = monsterParameters.navigationSpeed;
    }

    private bool IsPlayerVisible()
    {
        return IsPlayerInRadius(PlayerInFOVVisibilityDistance)
               && IsPlayerInFOV()
               && !IsObstacleBetweenPlayerAndMonster()
               || IsPlayerInRadius(PlayerBackVisibilityAngle);
    }

    private bool IsPlayerInRadius(float radius)
    {
        return HelpMethods.IsNear(PlayerBody.transform, transform, radius);
    }

    private bool IsPlayerInFOV()
    {
        return _directionFinder.MovementVector.GetAngle(PlayerBody.transform.position - transform.position) <
               PlayerVisibilityAngle / 2;
    }

    private bool IsObstacleBetweenPlayerAndMonster()
    {
        var nearColliders = Physics2D.OverlapCircleAll(transform.position, PlayerInFOVVisibilityDistance, playerMask);
        var isObstacleBetweenPlayerAndMonster = true;
        if (nearColliders.Length != 0)
        {
            var distance = (nearColliders[0].transform.position - transform.position).Length();
            var target = nearColliders[0].transform;
            var position = transform.position;
            var directionToTarget = (target.position - position).normalized;
            isObstacleBetweenPlayerAndMonster =
                Physics2D.Raycast(position, directionToTarget, (float) distance, wallsMask);
        }

        return isObstacleBetweenPlayerAndMonster;
    }
}