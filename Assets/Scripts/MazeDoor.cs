using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeDoor : MonoBehaviour
{
    public bool isOpen;
    public int leverCount => levels.Count;
    public GameObject door;

    [SerializeField] public List<MazeLever> levels;
    [SerializeField] public GameObject reaction;
    void Update()
    {
        isOpen = !levels.Select(x => x.isOff).Contains(true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            reaction.SetActive(reaction);
        }
    }
}