using UnityEngine;

public class squaremovement : MonoBehaviour
{
    private const float Acceleration = 3;

    private Rigidbody2D _rigidBodyComponent;

    private BoxCollider2D _collider;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidBodyComponent = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var w = Input.GetKey(KeyCode.W) ? 1 : 0;
        var s = Input.GetKey(KeyCode.S) ? -1 : 0;
        var a = Input.GetKey(KeyCode.A) ? 1 : 0;
        var d = Input.GetKey(KeyCode.D) ? -1 : 0;
        var space = Input.GetKey(KeyCode.Space) ? -1 : 0;
        var movementVector = new Vector2(-(a + d), w + s);
        _rigidBodyComponent.velocity = movementVector * Acceleration;
        if (!(movementVector.magnitude > Mathf.Epsilon)) return;
        var angle = new Vector3(0 ,0, movementVector.GetAngle());
        transform.rotation = Quaternion.Euler(angle);
    }
}