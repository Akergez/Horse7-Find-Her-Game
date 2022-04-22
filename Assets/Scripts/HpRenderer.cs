using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public abstract class HpRenderer : MonoBehaviour
{
    private Image _progressBar;
    [SerializeField] private string toDisplay;

    private void Start()
    {
        _progressBar = GetComponent<Image>();
    }

    void Update()
    {
        switch (toDisplay)
        {
            case "hunger":
                _progressBar.fillAmount = (float) (BigData.Player.Hunger / 5 * 0.05);
                break;
            case "HP":
                _progressBar.fillAmount = (float) (BigData.Player.HealtPoints / 5 * 0.05);
                break;
        }
    }
}