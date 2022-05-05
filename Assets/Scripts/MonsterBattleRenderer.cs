using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MonsterBattleRenderer : MonoBehaviour
    {
        [SerializeField]
        public SpriteRenderer SpriteRenderer;
        public MonsterBehaviour MonsterBehaviour;

        public void Update()
        {
            var color = SpriteRenderer.color;
            color.a = (float) (MonsterBehaviour.attackReadyness / 5);
            SpriteRenderer.color = color;
        }
    }
}