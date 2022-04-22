using System;
using System.Collections;
using Classes;
using DefaultNamespace;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    public static int BasicDamage = 20;
    public static Transform Transform;
    private bool _coroutineStarted;
    public static Monster Monster;
    public SpriteRenderer SpriteRenderer;
    [SerializeField]
    public Canvas HPCanvas;
    [SerializeField]
    public double Hp;

    public void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Transform = GetComponent<Transform>();
        Monster = new Monster();
        BigData.MonstersMap[this] = Monster;
    }

    public void Update()
    {
        if (!(BigData.Player == null || _coroutineStarted))
            StartCoroutine(AttackCoroutine());
        if (Monster.IsAlive == false)
        {
            Destroy(SpriteRenderer);
            Destroy(HPCanvas);
        }

        _coroutineStarted = true;
        Hp = Monster.HealtPoints;
    }

    private static IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if ((BigData.Player.PlayerBehaviour.transform.position - Transform.position).Length() < 1)
            {
                BigData.Player.GetDamage(BasicDamage);
            }

            yield return new WaitForSeconds(5);
        }
    }
}