using UnityEngine;

public class MonsterLiveBehaviour : MonoBehaviour
{
    [SerializeField] public double healthPoints;
    [SerializeField] public bool isAlive;
    
    public MonsterParameters monsterParameters;
    
    public void Start()
    {
        healthPoints = monsterParameters.initialHealthPoints;
        monsterParameters = GetComponent<MonsterParameters>();
    }
    public void Update()
    {
        if (!isAlive)
        {
            Destroy(this);
        }
    }
    public void OnDestroy()
    {
        Destroy(monsterParameters.monsterContainer);
    }

    public void GetDamage(double damage)
    {
        if (healthPoints >= damage)
            healthPoints -= damage;
        else
            healthPoints = 0;
        UpdateState();
    }
    private void UpdateState()
    {
        if (healthPoints == 0)
            isAlive = false;
    }
}