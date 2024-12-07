using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{

    public Vector3 desiredRotation;


    public AudioSource turn;
    public bool doRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void rotate() {
        gameObject.transform.localEulerAngles = desiredRotation;
        if(!doRotate) {
            doRotate=true;
            StartCoroutine(waitThenPlay());

        }

        Debug.Log("This is running0");
    }

    public IEnumerator waitThenPlay() {
        yield return new WaitForSeconds(1.2f);
        turn.Play();
        doRotate = true;
    }
}
