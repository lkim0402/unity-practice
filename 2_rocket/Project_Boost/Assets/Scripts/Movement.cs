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
            mainThrust.Pause();
            audioSource.Pause();
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A))
        {
            if (!rightThrust.isPlaying)
            {
                rightThrust.Play();
                Debug.Log("right thrust!");
            } 
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            
            if (!leftThrust.isPlaying)
            {
                leftThrust.Play();
                Debug.Log("left thrust!");
            }
            ApplyRotation(-rotationSpeed);
        }
        else 
        {
            rightThrust.Pause();
            leftThrust.Pause();
        }
    }

    private void ApplyRotation(float rotationSpeed)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false; //un-freezing rotation
    }
}
