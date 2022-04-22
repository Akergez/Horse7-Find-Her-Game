using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HpRenderer : MonoBehaviour
{
    [FormerlySerializedAs("HealthPointsText")] public Text healthPointsText;

    private Image ProgressBar;
    [SerializeField]
    private string toDisplay;

    private void Start()
    {
        ProgressBar = GetComponent<Image>();
    }

    void Update()
    {
        switch (toDisplay)
        {
            case "hunger":
                ProgressBar.fillAmount = (float)(BigData.Player.Hunger/5 * 0.05);
                break;
            case "HP":
                ProgressBar.fillAmount = (float)(BigData.Player.HealtPoints/5 * 0.05);
                break;
        }
    }
}
