using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float timeToWait = 2f;
    MeshRenderer renderer;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        renderer= GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();

        renderer.enabled = false;
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToWait){
            // Debug.Log(timeToWait + " seconds passed!");
            renderer.enabled = true;
            rigidbody.useGravity = true;
        }
    }
}
