using System;
using System.Reflection;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class PlayerParameterRenderer : MonoBehaviour
{
    private Image _progressBar;
    [SerializeField] private EntityParameter toDisplay;
    [SerializeField] private PlayerParameters PlayerParameters;
    void Start()
    {
        _progressBar = GetComponent<Image>();
    }

    void Update()
    {
        switch (toDisplay)
        {
            case EntityParameter.Hunger:
                _progressBar.fillAmount = (float) (Math.Truncate(PlayerParameters.playerLiveBehaviour.Hunger / 10) * 0.10);
                break;
            case EntityParameter.Hp:
                _progressBar.fillAmount = (float) (PlayerParameters.playerLiveBehaviour.HealtPoints / 5 * 0.05);
                break;
            case EntityParameter.BattleReadyness:
                _progressBar.fillAmount = (float) (PlayerParameters.playerAttackBehaviour.Increment * 0.25);
                break;
        }
    }
}