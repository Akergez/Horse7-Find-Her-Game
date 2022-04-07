using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private const float Acceleration = 1;

    private Rigidbody2D _rigidBodyComponent;

    public SpriteRenderer spriteRenderer;

    private Transform _transform;

    private PlayerBehaviour _playerBehaviour;

// Start is called before the first frame update
    private void Start()
    {
        _rigidBodyComponent = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        _playerBehaviour = (PlayerBehaviour) FindObjectOfType(typeof(PlayerBehaviour));
    }

    // Update is called once per frame
    private void Update()
    {
        var w = Input.GetKey(KeyCode.W) ? 0.1 : 0;
        var s = Input.GetKey(KeyCode.S) ? -0.1 : 0;
        var a = Input.GetKey(KeyCode.A) ? 0.1 : 0;
        var d = Input.GetKey(KeyCode.D) ? -0.1 : 0;
        if (w + s + a + d != 0)
            _playerBehaviour.isMoving = true;

        var movementVector = new Vector2(-((float) a + (float) d), (float) w + (float) s);
        movementVector.Normalize();

        _rigidBodyComponent.velocity = movementVector * Acceleration;
        if (!(movementVector.magnitude > Mathf.Epsilon)) return;
        var angle = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(angle);

        //var positionY = _transform.position.y / 0.25;
        //_spriteRenderer.sortingOrder = -(int) positionY * 100;
    }
}