using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerParameters : MonoBehaviour
{
    [SerializeField] public GameObject playerContainer;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float attackRadius;
    [SerializeField] public double initialHp;
    [SerializeField] public double initialHunger;
    [SerializeField] public float baseSpeed;
    [SerializeField] public float runningSpeed;

    public Animator animator;
    public Transform playerBody;

    public PlayerMovementBehaviour playerMovementBehaviour;
    public PlayerLiveBehaviour playerLiveBehaviour;
    public PlayerAttackBehaviour playerAttackBehaviour;

    public Vector3 MovementVector => playerMovementBehaviour.movement;

    private void InitializeComponents()
    {
        animator = GetComponent<Animator>();
        playerMovementBehaviour = GetComponent<PlayerMovementBehaviour>();
        playerLiveBehaviour = GetComponent<PlayerLiveBehaviour>();
        playerAttackBehaviour = GetComponent<PlayerAttackBehaviour>();
        playerBody = GetComponent<Transform>();
    }

    public void Start()
    {
        InitializeComponents();
    }

    private void HandleDeath()
    {
        SceneManager.LoadScene("MazeDeadScreen");
    }

    public void Update()
    {
        if (!playerLiveBehaviour.IsAlive)
        {
            HandleDeath();
            Destroy(playerContainer);
        }
    }

    public void GetDamage(double damage)
    {
        playerLiveBehaviour.GetDamage(damage);
    }
}