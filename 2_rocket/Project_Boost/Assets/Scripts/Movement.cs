using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float rocketSpeed = 1000f;
    [SerializeField] float rotationSpeed = 1f;

    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainThrust;
    [SerializeField] ParticleSystem leftThrust;
    [SerializeField] ParticleSystem rightThrust;
    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        audioSource = GetComponent<AudioSource>();

        // mainThrust.Stop();
        // rightThrust.Stop();
        // leftThrust.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space))
        {
            // thrust particle effect
            if (!mainThrust.isPlaying)
            {
                mainThrust.Play();
                Debug.Log("Main thrust?");
            }

            rb.AddRelativeForce(Vector3.up * rocketSpeed * Time.deltaTime);
            if (!audioSource.isPlaying) 
            {
                audioSource.PlayOneShot(mainEngine);
            }  
        } 
        else 
        {
            mainThrust.Stop();
            audioSource.Stop();
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
            if (!rightThrust.isPlaying)
            {
                rightThrust.Play();
                Debug.Log("right thrust!");
            } 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            
            ApplyRotation(-rotationSpeed);
            if (!leftThrust.isPlaying)
            {
                leftThrust.Play();
                Debug.Log("left thrust!");
            }
        }
        else 
        {
            rightThrust.Stop();
            leftThrust.Stop();
        }
    }

    private void ApplyRotation(float rotationSpeed)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false; //un-freezing rotation
    }
}
