using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
  void OnCollisionEnter(Collision other)
  {
    if(other.gameObject.tag == "Player"){
      GetComponent<MeshRenderer>().material.color = Color.cyan;
      gameObject.tag = "Hit"; // When hit, change tag to "Hit"
    }
  }
}
