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
        if (Input.GetKey(KeyCode.LeftShift))
            Speed *= Parameters.runningSpeed;
        else
            Speed *= Parameters.baseSpeed;

        if (!IsPlayerFreezed)
            rb.MovePosition(rb.position + movement * (Time.fixedDeltaTime * Speed));
    }


    public void SetPlayerFreezed(bool isFreezed)
    {
        IsPlayerFreezed = isFreezed;
    }

    public IEnumerator JumpCoroutine()
    {
        var speed = 800;
        var gs = rb.gravityScale;
        rb.gravityScale = 0;
        while (speed>0)
        {
            rb.AddForce(Vector2.up*speed);
            speed -= 50;
            yield return null;
        }

        rb.gravityScale = gs;
    }
}