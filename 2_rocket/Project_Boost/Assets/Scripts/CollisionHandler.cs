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

    //caching
    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    { 
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) return;

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

        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextScene", delaySeconds);
    }
    void CrashSequence() 
    {
        isTransitioning = true;
        audioSource.Stop();

        audioSource.PlayOneShot(collision);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", delaySeconds);

        // GetComponent<Movement>().enabled = true;
        // No need to include this line because the ReloadScene overwrites this

    }
    void LoadNextScene()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int indexToLoad;

        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
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
}
