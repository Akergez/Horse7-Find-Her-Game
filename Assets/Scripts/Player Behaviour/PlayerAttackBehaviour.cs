using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerParameters Parameters;
    public int Increment = 4;
    public float AttackRadius => Parameters.AttackRadius;


    public void Start()
    {
        Parameters = GetComponent<PlayerParameters>();
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

            foreach (var monster in BigData.MonstersMap.Where(x =>
                         HelpMethods.IsNear(x.Key.transform, transform, AttackRadius))) //ToDo разхардкорить
            {
                var damageCoef = (Increment * 0.25 * 20);
                monster.Value.GetDamage(damageCoef);
            }

            Increment = 0;

            yield return new WaitForSeconds(0.5f);
        }
    }
}