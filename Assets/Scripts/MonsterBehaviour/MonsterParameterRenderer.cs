using System;
using System.Collections;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class MonsterParameterRenderer : MonoBehaviour
{
    private Image _progressBar;
    [SerializeField] public EntityParameter parameterToRender;
    [SerializeField] public MonsterParameters monsterParameters;

    private MonsterAttackBehaviour MonsterAttackBehaviour =>
        (MonsterAttackBehaviour) monsterParameters.monsterAttackBehaviour;

    private void Start()
    {
        _progressBar = GetComponent<Image>();
    }


    void FixedUpdate()
    {
        switch (parameterToRender)
        {
            case EntityParameter.Hp:
                _progressBar.fillAmount = (float) (monsterParameters.monsterLiveBehaviour.healthPoints / 5 * 0.05);
                break;
            case EntityParameter.BattleReadyness:
                _progressBar.fillAmount = (float) MonsterAttackBehaviour.attackReadyness / 5;
                break;
            case EntityParameter.Hunger:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}