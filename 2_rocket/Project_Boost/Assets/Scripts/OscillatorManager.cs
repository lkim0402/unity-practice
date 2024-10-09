using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorManager : MonoBehaviour
{
    [SerializeField] GroupOscillator[] movingObjects;
    [SerializeField] float delaySeconds = 1f;

    [SerializeField] float period = 4f;
    [SerializeField] Vector3 movementVector;
    void Start()
    {
        Debug.Log("Hello");
        StartCoroutine(ManageOscillator());
    }

    // Update is called once per frame
    IEnumerator ManageOscillator()
    {
        GroupOscillator currentObject = movingObjects[0];
        StartCoroutine(currentObject.Oscillate(period, movementVector));
        yield break;

        // for (int i = 0; i < movingObjects.Length; i++)
        // {
        //     // movingObjects[i].Oscillate(period, movementVector); //doesn't work because you're not calling the coroutine itself!!
        //     GroupOscillator currentObject = movingObjects[i];

        //     Debug.Log("(OscillatorManager.cs) Current object: "+ currentObject.transform.name);
        //     Debug.Log("(OscillatorManager.cs) Current object position: "+ currentObject.transform.localPosition);

        //     StartCoroutine(currentObject.Oscillate(period, movementVector));
        //     yield return new WaitForSeconds(delaySeconds);
        // } 
    }
}
