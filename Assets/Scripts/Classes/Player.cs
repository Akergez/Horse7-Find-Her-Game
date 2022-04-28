using UnityEngine;

public class Player : Entity
{
    public double Hunger { get; set; }
    public PlayerBehaviour PlayerBehaviour { get; }

    public Player(PlayerBehaviour playerBehaviour)
    {
        HealtPoints = 100;
        Hunger = 100;
        PlayerBehaviour = playerBehaviour;
    }

    public void RecalculateHunger()
    {
        if (PlayerBehaviour.playerMovement.movement != Vector2.zero)
            if (Hunger > 0)
                Hunger -= 1;
            else if (HealtPoints >= 0)
                HealtPoints -= 1;

        if (Hunger <= HealtPoints) return;
        HealtPoints++;
        Hunger -= 1;
    }

    public override void GetDamage(double damage)
    {
        if (HealtPoints >= damage)
            HealtPoints -= damage;
        else
            HealtPoints = 0;
    }
}