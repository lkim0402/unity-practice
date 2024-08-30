using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
  void OnCollisionEnter(Collision other)
  {
    Debug.Log("Bumped into a wall");
    GetComponent<MeshRenderer>().material.color = Color.cyan;
  }
}
