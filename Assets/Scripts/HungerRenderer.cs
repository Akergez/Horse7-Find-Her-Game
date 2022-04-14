using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class HungerRenderer : MonoBehaviour
{
    public Text HungerPoints;

    void Update()
    {
        HungerPoints.text = (BigData.Player.Hunger / 5).ToString();
        HungerPoints.color = Color.green;
    }
}