﻿using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour
{
    public GameObject player; // 玉のオブジェクト

    private Vector3 offset; // 玉からカメラまでの距離

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}