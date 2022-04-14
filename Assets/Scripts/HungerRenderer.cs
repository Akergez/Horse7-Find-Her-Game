using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HungerRenderer : MonoBehaviour
{
    [FormerlySerializedAs("HungerPoints")] public Text hungerPoints;

    void Update()
    {
        hungerPoints.text = (GameManager.PlayerRepository.Hunger / 5).ToString();
        hungerPoints.color = Color.green;
    }
}