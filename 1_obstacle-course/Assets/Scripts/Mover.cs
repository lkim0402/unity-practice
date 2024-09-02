using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    int moveSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        PrintStatement();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PrintStatement()
    {
        Debug.Log("Welcome to the game!");
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
        
    }
}
