﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > 0)
        {
            if (player.transform.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, -10);
            }
        }
    }
}