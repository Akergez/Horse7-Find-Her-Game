using System;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace.Player_Behaviour
{
    public class PlayerSomethingCountRenderer : MonoBehaviour
    {
        [SerializeField] public PlayerParameters playerParameters;

        [SerializeField] public InventoryItemType itemToRender;
        public int Food => playerParameters.foodCount;
        public int Money => playerParameters.moneyCount;
        public int Arm => playerParameters.armCount;

        private Text Text;

        public void Start()
        {
            Text = GetComponent<Text>();
        }

        public void Update()
        {
            switch (itemToRender)
            {
                case InventoryItemType.Food:
                    Text.text = Food.ToString();
                    break;
                case InventoryItemType.Money:
                    Text.text = Money.ToString();
                    break;
                case InventoryItemType.Arm:
                    Text.text = Arm.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}