using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class DisableElement : MonoBehaviour
    {
        [SerializeField] public GameObject GameObject;

        public void Start()
        {
            StartCoroutine(DisableObjectCoroutine());
        }

        public IEnumerator DisableObjectCoroutine()
        {
            while (!GameObject.activeSelf)
            {
                yield return null;
            }
            yield return new WaitForSeconds(6);
            GameObject.SetActive(false);
        }
    }
}