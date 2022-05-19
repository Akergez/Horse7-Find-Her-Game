using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class MazeDoor : MonoBehaviour
{
    public bool isOpen;
    public int leverCount => levels.Count;
    public GameObject door;

    [SerializeField] public List<MazeLever> levels;
    [SerializeField] public GameObject reactionForNotAllLevelsUsed;
    [SerializeField] public GameObject reactionForAllLevelsUsed;

    void Update()
    {
        isOpen = !levels.Select(x => x.isOff).Contains(true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isOpen)
                reactionForAllLevelsUsed.SetActive(true);
            else
                reactionForNotAllLevelsUsed.SetActive(true);
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        reactionForAllLevelsUsed.SetActive(false);
        reactionForNotAllLevelsUsed.SetActive(false);
    }
}