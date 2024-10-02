using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //parameters
    [SerializeField] float delaySeconds = 2f;
    [SerializeField] AudioClip collision;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;

    //caching
    AudioSource audioSource;
    // Collider collider;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    { 
        audioSource = GetComponent<AudioSource>();
        // collider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        ProcessKeys();
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisabled) return;

        switch(other.gameObject.tag) {
            case "Friendly": 
                //do nothing
                Debug.Log("You're safe!");
                break;
            // In both cases we load a new scene and begin from scratch
            case "Finish":
                NextSceneSequence();
                break;
            case "Obstacle": 
                CrashSequence();
                break;
        }
    }

    void NextSceneSequence() 
    {
        // because this is set to true, even though OnCollisionEnter is 
        // called again it will just return
        isTransitioning = true;
        audioSource.Stop();

        // effects
        audioSource.PlayOneShot(success);
        successParticle.Play();

        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextScene", delaySeconds);
    }
    void CrashSequence() 
    {
        isTransitioning = true;
        audioSource.Stop();

        // effects
        audioSource.PlayOneShot(collision);
        crashParticle.Play();

        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", delaySeconds);

        // GetComponent<Movement>().enabled = true;
        // No need to include this line because the ReloadScene overwrites this
    }
    public void LoadNextScene()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int indexToLoad;

        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            // Start level from beginning if we reached the maximum level
            indexToLoad = 0;
        } 
        else {
            indexToLoad = nextLevelIndex;
        }
        SceneManager.LoadScene(indexToLoad);
    }
    void ReloadScene()
    {
        // Reloading the scene
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    void ProcessKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextScene();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; //toggle collision
        }
    }
}
