using UnityEngine;

public class MonsterInitializer : MonoBehaviour
{
    public MonsterParameters monsterParameters;
    
    public void Start()
    {
        monsterParameters = GetComponent<MonsterParameters>();
    }
}