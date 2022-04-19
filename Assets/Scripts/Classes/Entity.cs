using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity
{
    public int HealtPoints { get; set; }
    public void GetDamage(int damage)
    {
        if (HealtPoints >= damage)
            HealtPoints -= damage;
        else
            HealtPoints = 0;
    }
}
