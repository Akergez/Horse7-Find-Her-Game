using Enums;
using UnityEngine;
using UnityEngine.UI;

public class PlayerParameterRenderer : MonoBehaviour
{
    private Image _progressBar;
    [SerializeField] private EntityParameter toDisplay;
    void Start()
    {
        _progressBar = GetComponent<Image>();
    }

    void Update()
    {
        switch (toDisplay)
        {
            case EntityParameter.Hunger:
                _progressBar.fillAmount = (float) (BigData.Player.playerLiveBehaviour.Hunger / 5 * 0.05);
                break;
            case EntityParameter.Hp:
                _progressBar.fillAmount = (float) (BigData.Player.playerLiveBehaviour.HealtPoints / 5 * 0.05);
                break;
            case EntityParameter.BattleReadyness:
                _progressBar.fillAmount = (float) (BigData.Player.playerAttackBehaviour.Increment * 0.25);
                break;
        }
    }
}