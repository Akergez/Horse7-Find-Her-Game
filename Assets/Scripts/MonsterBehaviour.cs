using System;
using System.Collections;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    private static int BasicDamage = 20;
    private static Transform Monster;
    private bool _coroutineStarted;

    public void Start()
    {
        FindObjectOfType<PlayerBehaviour>();
        Monster = GetComponent<Transform>();
    }

    public void Update()
    {
        if (!_coroutineStarted)
        {
            StartCoroutine(AttackCoroutine());
            _coroutineStarted = true;
        }
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if ((GameManager.PlayerRepository.PlayerTransform.position - Monster.position).Length() < 1)
            {
                GameManager.PlayerInteractor.BeatPlayer(this, BasicDamage);
            }

            yield return new WaitForSeconds(5);
        }
    }
}