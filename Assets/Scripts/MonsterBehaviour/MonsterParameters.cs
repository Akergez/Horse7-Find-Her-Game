using UnityEngine;

public class MonsterParameters : MonoBehaviour
{
    [SerializeField] public double initialHealthPoints;
    [SerializeField] public int basicDamage;
    [SerializeField] public double attackRadius;
    [SerializeField] public float patrolingDistance;
    [SerializeField] public float playerInFOVVisibilityDistance;
    [SerializeField] public int playerVisibilityAngle;
    [SerializeField] public float playerBackVisibilityAngle;
    
    [SerializeField] public GameObject monsterContainer;

    private MonsterInitializer _monsterInitializer;
    public MonsterAttackBehaviour monsterAttackBehaviour;
    private MonsterNavigationBehaviour _monsterNavigationBehaviour;
    public MonsterLiveBehaviour monsterLiveBehaviour;
    
    public Transform monsterBody;

    public void Start()
    {
        monsterLiveBehaviour = GetComponent<MonsterLiveBehaviour>();
        monsterBody = GetComponent<Transform>();
        _monsterInitializer = GetComponent<MonsterInitializer>();
        monsterAttackBehaviour = GetComponent<MonsterAttackBehaviour>();
        _monsterNavigationBehaviour = GetComponent<MonsterNavigationBehaviour>();
        monsterLiveBehaviour = GetComponent<MonsterLiveBehaviour>();
    }
}