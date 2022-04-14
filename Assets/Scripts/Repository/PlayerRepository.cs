using UnityEngine;

namespace Repository
{
    public class PlayerRepository : Repository
    {
        public int HealthPoints { get; set; }
        public int Hunger { get; set; }
        
        public Transform PlayerTransform { get; set; }
        public override void Initialize()
        {
            HealthPoints = 100;
            Hunger = 100;
        }
    }
}