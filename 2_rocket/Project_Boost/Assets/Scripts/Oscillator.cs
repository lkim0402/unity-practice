using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector; //(10,0,0)
    [SerializeField] [Range(0,1)] float movementFactor; //number between 0 and 1

    [SerializeField] float period = 2f;
    const float tau = Mathf.PI * 2;
     
    void Start()
    {
        // startingPosition = GetComponent<Transform>().position;
        startingPosition = transform.position;
    }

    void Update()
    {
        float cycle = Time.time / period;
        float rawSinWave = Mathf.Sin(cycle * tau);

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
