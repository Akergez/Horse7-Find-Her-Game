using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class MonsterBattleRenderer : MonoBehaviour
    {
        [SerializeField] public SpriteRenderer spriteRenderer;
        public MonsterAttackBehaviour monsterAttackBehaviour;

        public void Update()
        {
            var color = spriteRenderer.color;
            color.a = (float) (monsterAttackBehaviour.attackReadyness / 5);
            spriteRenderer.color = color;
        }

        public void OnDestroy()
        {
            Destroy(spriteRenderer);
        }
    }
}