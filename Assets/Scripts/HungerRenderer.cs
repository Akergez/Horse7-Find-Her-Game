using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerRenderer : MonoBehaviour
{
    public Text HungerPoints;

    void Update()
    {
        var pb = (PlayerBehaviour)FindObjectOfType(typeof(PlayerBehaviour));
        HungerPoints.text = (pb.Player.Hunger / 5).ToString();
        HungerPoints.color = Color.green;
    }
}