using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector; //(10,0,0)
    float movementFactor; //number between 0 and 1

    [SerializeField] float period = 2f; //the point where it repeats itself
    const float tau = Mathf.PI * 2; //6.28, or one full oscillation
     
    void Start()
    {
        // startingPosition = GetComponent<Transform>().position;
        startingPosition = transform.position;
    }

    void Update()
    {
        // if (period == 0) return;
        if (period <= Mathf.Epsilon) return;

        // increases linearly
        float cycle = Time.time / period;
        
        // Sin function expects radians
        // whatever is outputted by Sin is between -1 and 1
        float rawSinWave = Mathf.Sin(cycle * tau); // we get the number of full oscillations

        // make range be from 0 to 2, then divide by 2 (so the maximum is 1 and  minimum is 0)
        movementFactor  = (rawSinWave + 1f) / 2f; 
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
