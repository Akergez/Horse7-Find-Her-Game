using System.Collections;
using UnityEngine;
using Random = System.Random;

public class PlayerBehaviour : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Rigidbody2D rigidbody2D;
    public Transform Transform;

    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Transform = GetComponent<Transform>();
        StartCoroutine(HungerRecalculateCoroutine());
    }

    public void Update()
    {
        playerMovement = (PlayerMovement) FindObjectOfType(typeof(PlayerMovement));
        if (GameManager.PlayerRepository.HealthPoints == 0)
            Destroy(playerMovement.spriteRenderer);
    }

    private IEnumerator HungerRecalculateCoroutine()
    {
        var rnd = new Random();
        while (true)
        {
            if(rnd.Next()%5==0)
                GameManager.PlayerInteractor.RecalculateHunger(this);
            if (rigidbody2D.velocity!=Vector2.zero)
            {
                GameManager.PlayerInteractor.RecalculateHunger(this);
                GameManager.PlayerInteractor.RecalculateHunger(this);
            }

            yield return new WaitForSeconds(2);
        }
    }
}