using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;
    private void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag != "Hit") {
            hits++;
            Debug.Log("Current number of bumps: " + hits);
        }
    }
}
