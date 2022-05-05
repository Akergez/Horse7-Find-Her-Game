using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public Transform point;
    Transform player;
    public float speed = 0.5f;
    public int positionOfPatrol;
    public float stoppingDistance;
    bool movingRight;
    bool chill;
    bool angry;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
            chill = true;

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            angry = false;

        if (chill)
            Chill();

        else if (angry)
            Angry();
        
        else
            GoBack();
    }
    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
            movingRight = false;

        else if (transform.position.x < point.position.x - positionOfPatrol)
            movingRight = true;

        if (movingRight)
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

        else
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 0.7f;
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
