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

public class MonsterInitializer : MonoBehaviour
{
    public static Monster Monster;

    [SerializeField]
    public GameObject monsterBody;

    public MonsterParameters MonsterParameters;
    
    
    public void Start()
    {
        MonsterParameters = GetComponent<MonsterParameters>();
        Monster = new Monster(MonsterParameters);
        BigData.MonstersMap[MonsterParameters] = Monster;
    }

    public void OnDestroy()
    {
        BigData.MonstersMap.Remove(MonsterParameters);
        Destroy(monsterBody);
    }

    public void FixedUpdate()
    {
        if (!BigData.MonstersMap[MonsterParameters].IsAlive)
        {
            Destroy(this);
        }
    }
}