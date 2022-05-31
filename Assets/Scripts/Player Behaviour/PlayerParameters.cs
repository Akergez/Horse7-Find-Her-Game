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
    [SerializeField] public double foodEffectivety;


    [SerializeField] public int foodCount;
    [SerializeField] public int moneyCount;
    [SerializeField] public int armCount;

    public Animator animator;
    public Transform playerBody;

    public PlayerMovementBehaviour playerMovementBehaviour;
    public PlayerLiveBehaviour playerLiveBehaviour;
    public PlayerAttackBehaviour playerAttackBehaviour;

    public Vector3 MovementVector => playerMovementBehaviour.movement;
    public static PlayerDataSaver Data;

    private void InitializeComponents()
    {
        animator = GetComponent<Animator>();
        playerMovementBehaviour = GetComponent<PlayerMovementBehaviour>();
        playerLiveBehaviour = GetComponent<PlayerLiveBehaviour>();
        playerAttackBehaviour = GetComponent<PlayerAttackBehaviour>();
        playerBody = GetComponent<Transform>();
        if (Data != null)
        {
            initialHp = Data.Hp;
            initialHunger = Data.Hunger;
            foodCount = Data.FoodCount;
            moneyCount = Data.MoneyCount;
        }
    }

    public void Awake()
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

        if (Input.GetKeyDown(KeyCode.Q) && foodCount > 0)
        {
            playerLiveBehaviour.IncreaseHunger(foodEffectivety);
            foodCount -= 1;
        }
    }

    public void GetDamage(double damage)
    {
        playerLiveBehaviour.GetDamage(damage);
    }

    public void IncreaseFood(int points)
    {
        foodCount += points;
    }

    public bool IncreaseMoney(int points)
    {
        if (moneyCount + points >= 0)
        {
            moneyCount += points;
            return true;
        }

        return false;
    }

    public void IncreaseArm(int points)
    {
        foodCount += points;
    }
}