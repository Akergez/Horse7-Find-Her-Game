using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Initializer : MonoBehaviour
    {
        public void Start()
        {
            GameManager.Initialize();
        }
    }
}