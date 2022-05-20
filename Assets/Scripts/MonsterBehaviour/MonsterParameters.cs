using UnityEngine;

public class MonsterParameters : MonoBehaviour
{
    [SerializeField] public double initialHealthPoints;
    [SerializeField] public int basicDamage;
    [SerializeField] public float AttackCD;
    [SerializeField] public double attackRadius;
    [SerializeField] public float patrolingDistance;
    [SerializeField] public float playerInFOVVisibilityDistance;
    [SerializeField] public int playerVisibilityAngle;
    [SerializeField] public float playerBackVisibilityAngle;
    [SerializeField] public float navigationSpeed;
    [SerializeField] public float followingSpeed;
    [SerializeField] public float monsterStamiinaInSeconds;
    
    [SerializeField] public GameObject monsterContainer;
    [SerializeField] public PlayerParameters playerBody;

    private MonsterInitializer _monsterInitializer;
    public EnemyAttackBehaviour monsterAttackBehaviour;
    private MonsterNavigationBehaviour _monsterNavigationBehaviour;
    public MonsterLiveBehaviour monsterLiveBehaviour;
    
    public Transform monsterBody;
    public Rigidbody2D Rigidbody2D;

    public void Start()
    {
        monsterLiveBehaviour = GetComponent<MonsterLiveBehaviour>();
        monsterBody = GetComponent<Transform>();
        _monsterInitializer = GetComponent<MonsterInitializer>();
        monsterAttackBehaviour = GetComponent<EnemyAttackBehaviour>();
        _monsterNavigationBehaviour = GetComponent<MonsterNavigationBehaviour>();
        monsterLiveBehaviour = GetComponent<MonsterLiveBehaviour>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
}