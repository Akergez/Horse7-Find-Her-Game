namespace Classes
{
    public class Monster : Entity
    {
        public MonsterParameters MonsterInitializer;

        public Monster(MonsterParameters monsterInitializer)
        {
            MonsterInitializer = monsterInitializer;
        }

        public override void GetDamage(double damage)
        {
            if (HealtPoints >= damage)
                HealtPoints -= damage;
            else
                HealtPoints = 0;
            UpdateState();
            MonsterInitializer._monsterAttackBehaviour.HandleDamage();
        }

    }
}