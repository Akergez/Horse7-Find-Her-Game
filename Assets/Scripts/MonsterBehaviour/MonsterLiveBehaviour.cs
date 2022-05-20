using System.Collections;
using UnityEngine;

public class MonsterLiveBehaviour : MonoBehaviour
{
    [SerializeField] public double healthPoints;
    [SerializeField] public bool isAlive;
    
    public MonsterParameters monsterParameters;
    
    public void Start()
    {
        monsterParameters = GetComponent<MonsterParameters>();
        healthPoints = monsterParameters.initialHealthPoints;
        monsterParameters = GetComponent<MonsterParameters>();
    }
    public void Update()
    {
        if (!isAlive)
        {
            Destroy(this);
        }
    }
    public void OnDestroy()
    {
        Destroy(monsterParameters.monsterContainer);
    }

    public void GetDamage(double damage)
    {
        if (healthPoints >= damage)
            healthPoints -= damage;
        else
            healthPoints = 0;
        UpdateState();
        HandleKnockback(damage/100);
    }

    public void HandleKnockback(double damage)
    {
        var knockbackVector = (monsterParameters.transform.position-monsterParameters.playerBody.transform.position).normalized;
        StartCoroutine(KnockbackCoroutine(knockbackVector * (float)damage));
    }

    public IEnumerator KnockbackCoroutine(Vector2 knockbackVector)
    {
        var scale = 40;
        var totalForce = Vector2.zero;
        while (scale>0)
        {
            monsterParameters.Rigidbody2D.AddForce(knockbackVector * scale);
            totalForce += knockbackVector * scale;
            scale -= 10;
            yield return null;
        }

        yield return null;
        monsterParameters.Rigidbody2D.AddForce(-totalForce);
    }
    private void UpdateState()
    {
        if (healthPoints == 0)
            isAlive = false;
    }
}