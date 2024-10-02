using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float rocketSpeed = 1000f;
    [SerializeField] float rotationSpeed = 1f;

    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
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
            StartThrusting();
        }
        else
        {
            audioSource.Stop();
            mainThrustParticles.Stop();        
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * rocketSpeed * Time.deltaTime);

        // only play the audio if you're not already playing
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }

        // only play the particles if you're not already playing
        if (!mainThrustParticles.isPlaying)
        {
            mainThrustParticles.Play();
            Debug.Log("Main thrust!");
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
            if (!rightThrustParticles.isPlaying)
            {
                rightThrustParticles.Play();
                Debug.Log("Going left - right thrust!");
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            
            ApplyRotation(-rotationSpeed);
            if (!leftThrustParticles.isPlaying)
            {
                leftThrustParticles.Play();
                Debug.Log("Going right - left thrust!");
            } 
        }
        else 
        {
            rightThrustParticles.Stop();
            leftThrustParticles.Stop();
        }
    }

    private void ApplyRotation(float rotationSpeed)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false; //un-freezing rotation
    }


}
