namespace Classes
{
    public class Monster : Entity
    {
        public MonsterBehaviour MonsterBehaviour;

        public Monster(MonsterBehaviour monsterBehaviour)
        {
            MonsterBehaviour = monsterBehaviour;
        }

        public override void GetDamage(double damage)
        {
            if (HealtPoints >= damage)
                HealtPoints -= damage;
            else
                HealtPoints = 0;
            UpdateState();
            MonsterBehaviour.HandleDamage();
        }

    }
}