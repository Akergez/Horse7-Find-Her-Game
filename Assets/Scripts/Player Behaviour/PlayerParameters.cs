using System.Collections;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerParameters : MonoBehaviour
{
    [SerializeField] public GameObject playerContainer;

    [SerializeField] public float moveSpeed;

    [SerializeField] public Animator animator;

    [SerializeField] public float AttackRadius;

    [SerializeField] public double InitialHp;
    
    [SerializeField] public double InitialHunger;

    [SerializeField] public Transform PlayerBody;

    [SerializeField] public PlayerMovementBehaviour PlayerMovementBehaviour;

    [SerializeField] public PlayerLiveBehaviour PlayerLiveBehaviour;
    [SerializeField] public PlayerAttackBehaviour PlayerAttackBehaviour;

    [SerializeField] public Vector3 MovementVector => PlayerMovementBehaviour.movement;

    public void InitializeComponents()
    {
        animator = GetComponent<Animator>();
        PlayerMovementBehaviour = GetComponent<PlayerMovementBehaviour>();
        PlayerLiveBehaviour = GetComponent<PlayerLiveBehaviour>();
        PlayerAttackBehaviour = GetComponent<PlayerAttackBehaviour>();
        PlayerBody = GetComponent<Transform>();
    }
    public void Start()
    {
        InitializeComponents();
        if (BigData.Player == null)
            BigData.Player = this;
    }

    public void HandleDeath()
    {
        BigData.ReloadData();
        SceneManager.LoadScene("MazeDeadScreen");
    }

    public void Update()
    {
        if (!PlayerLiveBehaviour.IsAlive)
        {
            HandleDeath();
            Destroy(playerContainer);
        }
    }

    public void GetDamage(double Damage)
    {
        PlayerLiveBehaviour.GetDamage(Damage);
    }
}