﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 0f);
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    [Range (0,1)][SerializeField] float movementFactor;
    Vector3 startingPos;
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;// grows continually from zero
        const float tau = Mathf.PI * 2; //about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
