using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class DisableElement : MonoBehaviour
    {
        [FormerlySerializedAs("GameObject")] [SerializeField] public GameObject ObjectToDisable;
        [FormerlySerializedAs("SecondsBeforeDisable")] [SerializeField] public float secondsBeforeDisable;

        public void Start()
        {
            StartCoroutine(DisableObjectCoroutine());
        }

        private IEnumerator DisableObjectCoroutine()
        {
            while (!ObjectToDisable.activeSelf)
            {
                yield return null;
            }
            yield return new WaitForSeconds(secondsBeforeDisable);
            ObjectToDisable.SetActive(false);
        }
    }
}