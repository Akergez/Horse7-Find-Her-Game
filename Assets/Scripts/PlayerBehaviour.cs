using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public Player player;
        public void Start()
        {
            player = new Player();
        }

        public void Update()
        {
            player.RecalculateHunger();
            if (player.HealtPoints == 0)
                PlayerMovement.Destroy(PlayerMovement._spriteRenderer);
        }
    }
}