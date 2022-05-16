using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject _player;
    void Start()
    {
        _player = GameObject.Find("player");
    }
    void Update()
    {
        var pos = _player.transform.position;
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
