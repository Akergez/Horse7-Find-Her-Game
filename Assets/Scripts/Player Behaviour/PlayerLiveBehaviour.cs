using System.Collections;
using UnityEngine;

public class PlayerLiveBehaviour : MonoBehaviour
{
    private PlayerParameters Parameters;

    [SerializeField] public float HungerRecalculateFrequency;
    [SerializeField] public double Hunger;
    [SerializeField] public double HealtPoints;
    [SerializeField] public bool IsAlive = true;

    public void Start()
    {
        Parameters = GetComponent<PlayerParameters>();
        Hunger = Parameters.initialHunger;
        HealtPoints = Parameters.initialHp;
        StartCoroutine(HungerRecalculateCoroutine());
    }

    public void OnDestroy()
    {
        StopCoroutine(HungerRecalculateCoroutine());
    }

    private IEnumerator HungerRecalculateCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(HungerRecalculateFrequency);
            RecalculateHunger();
        }
    }

    public void RecalculateHunger()
    {
        if (Parameters.MovementVector != Vector3.zero)
            if (Hunger > 0)
                Hunger -= Input.GetKey(KeyCode.LeftShift) ? 3 : 1;
            else if (HealtPoints >= 0)
                HealtPoints -= 1;

        if (Hunger <= HealtPoints) return;
        HealtPoints++;
        Hunger -= 1;
    }

    public void GetDamage(double damage)
    {
        if (HealtPoints >= damage)
            HealtPoints -= damage;
        else
            HealtPoints = 0;
        if (HealtPoints == 0)
            IsAlive = false;
    }
}