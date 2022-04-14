using System.Collections;
using DefaultNamespace;
using UnityEngine;
using Random = System.Random;

public class PlayerBehaviour : MonoBehaviour
{
    public Player Player;

    private const float Acceleration = 1;

    private Rigidbody2D _rigidBodyComponent;

    public SpriteRenderer spriteRenderer;
    
    public Vector2 movementVector = Vector2.zero;
    
// Start is called before the first frame update
    private void Start()
    {
        _rigidBodyComponent = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Player = new Player(this);
        StartCoroutine(HungerRecalculateCoroutine());
        BigData.Player = Player;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Player.HealtPoints == 0)
            Destroy(spriteRenderer);
        Move();
        //var positionY = _transform.position.y / 0.25;
        //_spriteRenderer.sortingOrder = -(int) positionY * 100;
    }

    private void Move()
    {
        var w = Input.GetKey(KeyCode.W) ? 0.1 : 0;
        var s = Input.GetKey(KeyCode.S) ? -0.1 : 0;
        var a = Input.GetKey(KeyCode.A) ? 0.1 : 0;
        var d = Input.GetKey(KeyCode.D) ? -0.1 : 0;
        movementVector = new Vector2(-((float) a + (float) d), (float) w + (float) s);
        movementVector.Normalize();

        _rigidBodyComponent.velocity = movementVector * Acceleration;
        if (!(movementVector.magnitude > Mathf.Epsilon)) return;
        var angle = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(angle);
    }
    private IEnumerator HungerRecalculateCoroutine()
    {
        var rnd = new Random();
        while (true)
        {
            if(rnd.Next()%5==0)
                Player.RecalculateHunger();
            if (_rigidBodyComponent.velocity!=Vector2.zero)
            {
                Player.RecalculateHunger();
                Player.RecalculateHunger();
            }

            yield return new WaitForSeconds(2);
        }
    }
}