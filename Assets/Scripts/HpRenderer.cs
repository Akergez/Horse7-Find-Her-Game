using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HpRenderer : MonoBehaviour
{
    [FormerlySerializedAs("HealthPointsText")] public Text healthPointsText;
    void Update()
    {
        var pb = (PlayerBehaviour)FindObjectOfType(typeof(PlayerBehaviour));
        healthPointsText.text = (pb.Player.HealtPoints/5).ToString();
        healthPointsText.color = Color.red;
    }
}
