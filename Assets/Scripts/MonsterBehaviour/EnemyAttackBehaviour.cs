using UnityEngine;


public class EnemyAttackBehaviour : MonoBehaviour
{
    public MonsterParameters monsterParameters;
    
    public double AttackRadius => monsterParameters.attackRadius;
    
    public void Start()
    {
        monsterParameters = GetComponent<MonsterParameters>();
    }
}