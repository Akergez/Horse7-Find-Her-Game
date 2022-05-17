using System;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MonsterParameterRenderer : MonoBehaviour
{
    private Image _progressBar;
    [SerializeField] public EntityParameter parameterToRender;
    [SerializeField] public MonsterParameters MonsterParameters;
    private MonsterAttackBehaviour monsterAttackBehaviour => MonsterParameters._monsterAttackBehaviour;
    
    private void Start()
    {
        _progressBar = GetComponent<Image>();
    }
      

    void Update()
    {
        switch (parameterToRender)
        {
            case EntityParameter.Hp:
                _progressBar.fillAmount = (float)(BigData.MonstersMap[MonsterParameters].HealtPoints/5 * 0.05);
                break;
            case EntityParameter.BattleReadyness:
                _progressBar.fillAmount = (float)monsterAttackBehaviour.attackReadyness/5;
                break;
            case EntityParameter.Hunger:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}