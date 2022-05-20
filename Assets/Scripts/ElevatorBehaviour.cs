using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class ElevatorBehaviour : MonoBehaviour
    {
        [SerializeField] public GameObject Player;

        public Rigidbody2D rb => Player.GetComponent<Rigidbody2D>();
        public SpriteRenderer sr => Player.GetComponent<SpriteRenderer>();

        public Collider2D collider => Player.GetComponent<Collider2D>();

        [SerializeField] public GameObject popUp;

        public void OnCollisionEnter2D(Collision2D collision)
        {
            popUp.SetActive(true);
        }

        public void Update()
        {
            if (popUp.activeSelf && Input.GetKeyDown(KeyCode.E))
                StartCoroutine(GettingUpCoroutine());
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            popUp.SetActive(false);
        }

        public IEnumerator GettingUpCoroutine()
        {
            rb.gravityScale = 0;
            sr.sortingOrder = 1;
            while (rb.position.y < 60)
            {
                rb.AddForce(Vector2.up * 100);
                yield return null;
            }

            SceneManager.LoadScene("FinalDialog");
        }
    }
}