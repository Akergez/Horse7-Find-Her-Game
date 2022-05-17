using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class DirectionFinder : MonoBehaviour
    {
        [SerializeField] public Vector3 MovementVector;
        private Vector3 _previousPosition;
        [SerializeField] public Transform body;
        [SerializeField] public bool UseNull;
        [SerializeField] public float UpdateFrequency;

        public void Start()
        {
            _previousPosition = body.position;
            StartCoroutine(UpdateDirectionCoroutine());
        }
        
        private IEnumerator UpdateDirectionCoroutine()
        {
            while (true)
            {
                MovementVector = body.position - _previousPosition;
                _previousPosition = new Vector3(body.position.x, body.position.y, body.position.z);
                if (UseNull)
                    yield return null;
                else
                    yield return new WaitForSeconds(UpdateFrequency);
            }
        }
    }
}