using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {   var pos = player.position + offset;
        pos.x = transform.position.x;
        transform.position = pos;
    }
}
