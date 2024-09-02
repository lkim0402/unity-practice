using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float rocketSpeed = 1000f;
    [SerializeField] float rotationSpeed = 1f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
            rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)){
            // Vector3 vector = new Vector3(0, rocketSpeed * Time.deltaTime, 0);
            // rb.AddRelativeForce(vector);

            // rb.AddRelativeForce(Vector3.up);

            rb.AddRelativeForce(Vector3.up * rocketSpeed * Time.deltaTime);

        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    private void ApplyRotation(float speed)
    {
        
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
