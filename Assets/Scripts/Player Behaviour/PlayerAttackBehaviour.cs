using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
    private PlayerParameters Parameters;
    public int Increment = 4;
    public float AttackRadius => Parameters.attackRadius;
    [SerializeField] public LayerMask monsterMask;


    public void Start()
    {
        Parameters = GetComponent<PlayerParameters>();
        if (!Parameters.playerMovementBehaviour.isIn2D)
            StartCoroutine(AttackCoroutine());
    }

    public void OnDestroy()
    {
        StopCoroutine(AttackCoroutine());
    }

    public IEnumerator AttackCoroutine()
    {
        while (true)
        {
            var secondIncrement = 0;
            while (!Input.GetKey(KeyCode.Space))
            {
                if (Increment == 4)
                    yield return new WaitForSeconds(0.005f);
                else
                {
                    secondIncrement++;
                    if (secondIncrement == 20)
                    {
                        Increment++;
                        secondIncrement = 0;
                    }

                    yield return new WaitForSeconds(0.005f);
                }
            }

            foreach (var monster in GetMonstersNear()) //ToDo разхардкорить
            {
                var damageCoef = (Increment * 0.25 * 20);
                var monsterLiveBeh = monster.gameObject.GetComponent<MonsterLiveBehaviour>();
                monsterLiveBeh.GetDamage(damageCoef);
            }

            Increment = 0;

            yield return new WaitForSeconds(0.5f);
        }
    }

    private Collider2D[] GetMonstersNear()
    {
        return Physics2D.OverlapCircleAll(Parameters.transform.position, AttackRadius, monsterMask);
    }
}