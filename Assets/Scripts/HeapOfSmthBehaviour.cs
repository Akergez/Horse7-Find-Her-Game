using Enums;
using UnityEngine;
public class HeapOfSmthBehaviour : MonoBehaviour
{
    public GameObject HeapContainer;
    
    [SerializeField] private PlayerParameters _playerParameters;
    [SerializeField] public Enums.InventoryItemType heapType;
    [SerializeField] public int itemCount;
    private void OnCollisionEnter2D(Collision2D newCollision)
    {
        if (newCollision.gameObject.CompareTag("Player"))
        {
            switch (heapType)
            {
                case InventoryItemType.Food:
                    _playerParameters.IncreaseFood(itemCount);
                    break;
                case InventoryItemType.Money:
                    _playerParameters.IncreaseMoney(itemCount);
                    break;
            }
            Destroy(HeapContainer);
        }
    }
}