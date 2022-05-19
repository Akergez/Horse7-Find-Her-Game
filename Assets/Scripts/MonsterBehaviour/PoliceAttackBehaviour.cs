using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PoliceAttackBehaviour : EnemyAttackBehaviour
{
    public void FixedUpdate()
    {
        if (HelpMethods.IsNear(monsterParameters.monsterBody.transform, monsterParameters.playerBody.transform,
                AttackRadius))
        {
            SceneManager.LoadScene("center");
        }
    }
}