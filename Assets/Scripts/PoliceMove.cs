using UnityEngine;
using UnityEngine.SceneManagement;

public class PoliceMove : MonoBehaviour
{
    public Transform point;
    public float speed = 0.5f;
    public int positionOfPatrol;
    public bool movingRight;
    Transform player;
    public Collision2D collision;
    public float stoppingDistance;
    bool chill = false;
    bool angry = false;
    bool goBack = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player"))
        {
            collision = newCollision;
            Debug.Log("Gotcha");
            SceneManager.LoadScene("center");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            GoBack();
        }
    }
    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 0.9f;
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
