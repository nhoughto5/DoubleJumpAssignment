﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpin : MonoBehaviour
{
    public float rotationSpeed = 90f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);

    }
}
