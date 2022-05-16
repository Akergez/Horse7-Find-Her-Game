using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class BattleRenderer : MonoBehaviour
{
    private Image _progressBar;
    [SerializeField] private string toDisplay;

    private void Start()
    {
        _progressBar = GetComponent<Image>();
    }

    private void Update()
    {
        _progressBar.fillAmount = (float) (BigData.Player.PlayerBehaviour.Increment * 0.25);
    }
}