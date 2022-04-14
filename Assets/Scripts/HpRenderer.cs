using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HpRenderer : MonoBehaviour
{
    [FormerlySerializedAs("HealthPointsText")] public Text healthPointsText;
    void Update()
    {
        healthPointsText.text = (GameManager.PlayerRepository.HealthPoints/5).ToString();
        healthPointsText.color = Color.red;
    }
}
