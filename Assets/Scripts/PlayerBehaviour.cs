using System.Collections;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public Player Player;
    public Rigidbody2D rb;
    public int Increment = 4;
    public float moveSpeed = 1f;
    public Animator animator;
    public Vector2 movement;
    public bool IsPlayerFreezed { get; private set; }
    [SerializeField]
    public float AttackRadius;
    
    [SerializeField]
    public double Hp;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (BigData.Player == null)
            BigData.Player = new Player(this);
        BigData.Player.PlayerBehaviour = this;
        Player = BigData.Player;
        StartCoroutine(HungerRecalculateCoroutine());
        StartCoroutine(AttackCoroutine());
    }

    public void OnDestroy()
    {
        StopCoroutine(HungerRecalculateCoroutine());
        StopCoroutine(AttackCoroutine());
    }

    public void Death()
    {
        BigData.ReloadData();
        SceneManager.LoadScene("MazeDeadScreen");
    }

    public void Update()
    {
        Hp = BigData.Player.HealtPoints;
        if (!BigData.Player.IsAlive)
        {
            Death();
            Destroy(this);
        }

        HandleControls();
    }

    void HandleControls()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        var speedMultiplier = movement.x != 0 && movement.y != 0 ? 0.75f : 1f;
        if (!IsPlayerFreezed)
            rb.MovePosition(rb.position + movement * (Time.fixedDeltaTime * speedMultiplier));
    }

    public IEnumerator AttackCoroutine()
    {
        while (true)
        {
            var secondIncrement = 0;
            while (!Input.GetKey(KeyCode.Space))
            {
                if (Increment == 4)
                    yield return new WaitForSeconds(0.005f);
                else
                {
                    secondIncrement++;
                    if (secondIncrement == 20)
                    {
                        Increment++;
                        secondIncrement = 0;
                    }

                    yield return new WaitForSeconds(0.005f);
                }
            }

            foreach (var monster in BigData.MonstersMap.Where(x =>
                         HelpMethods.IsNear(x.Key.transform, transform, AttackRadius))) //ToDo разхардкорить
            {
                var damageCoef = (Increment * 0.25 * 20);
                monster.Value.GetDamage(damageCoef);
            }
            Increment = 0;

            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator HungerRecalculateCoroutine()
    {
        while (true)
        {
            Player.RecalculateHunger();
            yield return new WaitForSeconds(2); //ToDo расхардкорить
        }
    }

    public void SetPlayerFreezed(bool isFreezed)
    {
        IsPlayerFreezed = isFreezed;
    }
}