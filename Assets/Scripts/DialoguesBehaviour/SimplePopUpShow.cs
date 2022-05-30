using UnityEngine;

namespace DefaultNamespace.DialoguesBehaviour
{
    public class SimplePopUpShow : MonoBehaviour
    {
        public bool isPopup;
        public bool isPopupDestroyed;
        public GameObject popup;
        [SerializeField] public Transform player;
        [SerializeField] public float distance;

        private void OnCollisionEnter2D(Collision2D newCollision)
        {
            if (!isPopup && newCollision.gameObject.CompareTag("Player"))
            {
                isPopup = true;
                if (!isPopupDestroyed)
                    popup.SetActive(isPopup);
            }
        }

        void Update()
        {
            float distToPlayer = Vector2.Distance(transform.position, player.position);

            if (distToPlayer > distance)
            {
                HidePopUp();
            }
        }

        public void HidePopUp()
        {
            isPopup = false;
            popup.SetActive(isPopup);
        }

        public void DestroyPopUp()
        {
            isPopupDestroyed = true;
            popup.SetActive(false);
        }
    }
}