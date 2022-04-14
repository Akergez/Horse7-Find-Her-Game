using Repository;

namespace Interactors
{
    public class PlayerInteractor : Interactor
    {
        public PlayerRepository Repository;
        public void BeatPlayer(object sender, int Damage)
        {
            Repository.HealthPoints -= Damage;
        }

        public void RecalculateHunger(object sender)
        {
            if (Repository.Hunger > 0)
                Repository.Hunger -= 1;
            else
            if (Repository.Hunger >= 0)
                Repository.HealthPoints -= 1;
            if (Repository.Hunger <= Repository.HealthPoints) return;
            Repository.HealthPoints++;
            Repository.Hunger -= 1;
        }
    }
}