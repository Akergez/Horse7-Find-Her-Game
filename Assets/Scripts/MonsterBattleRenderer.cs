using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class MonsterBattleRenderer : MonoBehaviour
    {
        [FormerlySerializedAs("SpriteRenderer")] [SerializeField]
        public SpriteRenderer spriteRenderer;
        [FormerlySerializedAs("MonsterBehaviour")] public MonsterBehaviour monsterBehaviour;

        public void Update()
        {
            var color = spriteRenderer.color;
            color.a = (float) (monsterBehaviour.attackReadyness / 5);
            spriteRenderer.color = color;
        }

        public void OnDestroy()
        {
            Destroy(spriteRenderer);
        }
    }
}