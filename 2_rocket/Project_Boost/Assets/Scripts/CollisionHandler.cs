using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag) {
            case "Friendly": 
                //do nothing
                Debug.Log("You're safe!");
                break;
            case "Finish":
                Debug.Log("You're finished!");
                break;
            default: //everything else
                Debug.Log("You've bumped into an obstacle!");
                break;
        }
    }
}
