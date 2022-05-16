using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSprite : MonoBehaviour
{
    private SpriteRenderer _spriteToHide;

    private void Start()
    {
        _spriteToHide = GetComponent<SpriteRenderer>();
        _spriteToHide.enabled = false;
    }
}
