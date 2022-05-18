using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementBehaviour : MonoBehaviour
{
    public PlayerParameters Parameters;
    public Rigidbody2D rb;
    public Animator animator => Parameters.animator;
    public Vector2 movement;
    public bool IsPlayerFreezed { get; private set; }

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
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        var speedMultiplier = movement.x != 0 && movement.y != 0 ? 0.75f : 1f;
        var speed = speedMultiplier;
        if (Input.GetKey(KeyCode.LeftShift))
            speed *= Parameters.runningSpeed;
        else
            speed *= Parameters.baseSpeed;
    
        if (!IsPlayerFreezed)
            rb.MovePosition(rb.position + movement * (Time.fixedDeltaTime * speed));
    }


    public void SetPlayerFreezed(bool isFreezed)
    {
        IsPlayerFreezed = isFreezed;
    }
}