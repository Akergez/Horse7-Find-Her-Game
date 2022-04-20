public class Player : Entity
{
    public int Hunger { get; set; }
    public PlayerBehaviour PlayerBehaviour { get; }

    public Player(PlayerBehaviour playerBehaviour)
    {
        HealtPoints = 100;
        Hunger = 100;
        PlayerBehaviour = playerBehaviour;
    }

    public void RecalculateHunger()
    {
        if (Hunger > 0)
            Hunger -= 1;
        else
        if (HealtPoints >= 0)
                HealtPoints -= 1;
        if (Hunger <= HealtPoints) return;
        HealtPoints++;
        Hunger -= 1;
    }

    public void GetDamage(int damage)
    {
        if (HealtPoints >= damage)
            HealtPoints -= damage;
        else
            HealtPoints = 0;
    }
}