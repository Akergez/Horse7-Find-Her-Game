using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementBehaviour : MonoBehaviour
{
    public PlayerParameters Parameters;
    public Rigidbody2D rb;
    public Animator animator => Parameters.animator;
    public Vector2 movement;
    public bool IsPlayerFreezed { get; private set; }

    public float Speed;

    [SerializeField] public bool isIn2D;
    [SerializeField] public float jumpForse;

    private float hiddenSpeedMultiplier = 1;

    bool inAir;

    public void Start()
    {
        movement = Vector2.zero;
        Parameters = GetComponent<PlayerParameters>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        HandleControls();
    }

    void HandleControls()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (!isIn2D)
            movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && !inAir && isIn2D)
        {
            StartCoroutine(JumpCoroutine());
            //rb.AddForce(Vector2.up*jumpForse);
           inAir = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isIn2D)
            inAir = false;
    }

    void FixedUpdate()
    {
        var speedMultiplier = movement.x != 0 && movement.y != 0 ? 0.75f : 1f;
        Speed = speedMultiplier;
        if (Input.GetKey(KeyCode.LeftShift) && Parameters.playerLiveBehaviour.Hunger > Parameters.initialHunger / 10)
            Speed *= Parameters.runningSpeed * hiddenSpeedMultiplier;
        else
            Speed *= Parameters.baseSpeed * hiddenSpeedMultiplier;

        if (!IsPlayerFreezed)
            rb.MovePosition(rb.position + movement * (Time.fixedDeltaTime * Speed));
    }


    public void SetPlayerFreezed(bool isFreezed)
    {
        IsPlayerFreezed = isFreezed;
    }

    public IEnumerator JumpCoroutine()
    {
        hiddenSpeedMultiplier /= 5;
        var speed = 500;
        var gs = rb.gravityScale;
        rb.gravityScale = 0;
        while (speed>0)
        {
            rb.AddForce(Vector2.up*speed);
            speed -= 30;
            yield return null;
        }
        
        while (speed<600)
        {
            rb.AddForce(Vector2.down*speed);
            speed += 30;
            yield return null;
        }
        rb.gravityScale = gs;
        hiddenSpeedMultiplier *= 5;
    }
}