using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.DialoguesBehaviour;
using UnityEngine;
using UnityEngine.Serialization;

public class MazeDoor : MonoBehaviour
{
    public bool isOpen;
    public int leverCount => levels.Count;
    public GameObject door;

    [SerializeField] public bool isOpenByEditor;
    [SerializeField] public List<MazeLever> levels;
    [SerializeField] public GameObject reactionForAllLevelsUsed;
    public SimplePopUpShow firstPopUpShow;

    void Start()
    {
        firstPopUpShow = GetComponent<SimplePopUpShow>();
    }
    void Update()
    {
        isOpen = !levels.Select(x => x.isOff).Contains(true);
        if (isOpen || isOpenByEditor)
           firstPopUpShow.popup = reactionForAllLevelsUsed;
    }
}