using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class MonsterParameters : MonoBehaviour
{
    [SerializeField] public int basicDamage;
    public Transform Transform;
    [SerializeField] public double attackRadius;
    [SerializeField] public float PatrolingDistance;
    [SerializeField] public float PlayerInFOVVisibilityDistance;
    [SerializeField] public int PlayerVisibilityAngle;
    [SerializeField] public float PlayerBackVisibilityAngle;

    [FormerlySerializedAs("_monsterBehaviour")] [SerializeField] private MonsterInitializer monsterInitializer;
    [SerializeField] public MonsterAttackBehaviour _monsterAttackBehaviour;
    [SerializeField] private MonsterNavigationBehaviour _monsterNavigationBehaviour;

    public void Start()
    {
        Transform = GetComponent<Transform>();
        monsterInitializer = GetComponent<MonsterInitializer>();
        _monsterAttackBehaviour = GetComponent<MonsterAttackBehaviour>();
        _monsterNavigationBehaviour = GetComponent<MonsterNavigationBehaviour>();
    }
}