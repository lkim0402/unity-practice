using System;
using System.Collections;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector; // new Vector3(10,0,0); 
    float movementFactor; //number between 0 and 1

    [SerializeField] float period; //the point where it repeats itself
    const float tau = Mathf.PI * 2; //6.28, or one full oscillation
     
    void Start()
    {
        // startingPosition = GetComponent<Transform>().position;
        startingPosition = transform.position;
        StartCoroutine(Oscillate(period, movementVector, startingPosition));

    }

    public IEnumerator Oscillate(float period, Vector3 movementVector, Vector3 startingPosition)
    {
        // Debug.Log("(Oscillator.cs) starting position: " + startingPosition);
        // timestamp the local start time
        float localStartTime = Time.time;

        while (true)
        {
            // if (period == 0) return;
            // Mathf.Epsilon is suuuuper small, very close to 0
            // just use this to prevent precision errors
            if (period <= Mathf.Epsilon) yield break;

            
            // calculate time only after the local start time
            // cycle increases linearly
            // float cycle = (Time.time) / period;
            float cycle = (Time.time - localStartTime) / period;

            // Sin function expects radians
            // whatever is outputted by Sin is between -1 and 1
            float rawSinWave = Mathf.Sin(cycle * tau); // we get the number of full oscillations

            // make range be from 0 to 2 by adding 1, then divide by 2 
            // so the maximum is 1 and  minimum is 0
            movementFactor  = (rawSinWave + 1f) / 2f; 
            
            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPosition + offset;

            yield return null; // This causes the editor to not freeze!!!!
        }
    }

    // void Update()
    // {
    //             // if (period == 0) return;
    //     // Mathf.Epsilon is suuuuper small, very close to 0
    //     // just use this to prevent precision errors
    //     if (period <= Mathf.Epsilon) return;

    //     // cycle increases linearly
    //     float cycle = Time.time / period;
        
    //     // Sin function expects radians
    //     // whatever is outputted by Sin is between -1 and 1
    //     float rawSinWave = Mathf.Sin(cycle * tau); // we get the number of full oscillations

    //     // make range be from 0 to 2 by adding 1, then divide by 2 
    //     // so the maximum is 1 and  minimum is 0
    //     movementFactor  = (rawSinWave + 1f) / 2f; 
        
    //     Vector3 offset = movementVector * movementFactor;
    //     transform.position = startingPosition + offset;
    // }

}
