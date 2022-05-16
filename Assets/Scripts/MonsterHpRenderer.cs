using System;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MonsterHpRenderer : MonoBehaviour
{
    private Image _progressBar;
    [FormerlySerializedAs("ParameterToRender")] [SerializeField] public EntityParameter parameterToRender;

    [FormerlySerializedAs("_monsterBehaviour")] [SerializeField] private MonsterBehaviour monsterBehaviour;
    
    private void Start()
    {
        _progressBar = GetComponent<Image>();
    }
      

    void Update()
    {
        switch (parameterToRender)
        {
            case EntityParameter.Hp:
                _progressBar.fillAmount = (float)(BigData.MonstersMap[monsterBehaviour].HealtPoints/5 * 0.05);
                break;
            case EntityParameter.BattleReadyness:
                _progressBar.fillAmount = (float)monsterBehaviour.attackReadyness/5;
                break;
            case EntityParameter.Hunger:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}