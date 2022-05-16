using System;
using System.Runtime.InteropServices.ComTypes;
using DefaultNamespace;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class PlayerParameterRenderer : MonoBehaviour
{
    private Image _progressBar;
    [SerializeField] private Enums.EntityParameter toDisplay;
    void Start()
    {
        _progressBar = GetComponent<Image>();
    }

    void Update()
    {
        switch (toDisplay)
        {
            case EntityParameter.Hunger:
                _progressBar.fillAmount = (float) (BigData.Player.Hunger / 5 * 0.05);
                break;
            case EntityParameter.Hp:
                _progressBar.fillAmount = (float) (BigData.Player.HealtPoints / 5 * 0.05);
                break;
            case EntityParameter.BattleReadyness:
                _progressBar.fillAmount = (float) (BigData.Player.PlayerBehaviour.Increment * 0.25);
                break;
        }
    }
}