using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class walkieTalkiePulse : MonoBehaviour
{
    public bool isPulsing = false;

    private bool lightOn = false;
    public Material offMat;
    public Material onMat;

    public Light pointLight;

    public float flashTime = 1.0f;

    private float originalFlashTime;

    void Start() {
        originalFlashTime = flashTime;
    }
    public void startPulse() {
        isPulsing = true;
    }

    public void stopPulse() {
        isPulsing = false;
        GetComponent<MeshRenderer>().material = offMat;
        pointLight.enabled = false;
        lightOn = false;
    }

    void Update() {
        if(!isPulsing)
            return;
        
        flashTime-=Time.deltaTime;

        if(flashTime <= 0) {
            flashTime = originalFlashTime;
            if(lightOn){
                GetComponent<MeshRenderer>().material = offMat;
                pointLight.enabled = false;
                lightOn = false;
            } else {
                GetComponent<MeshRenderer>().material = onMat;
                pointLight.enabled = true;
                lightOn = true;
                GetComponent<AudioSource>().Play();
            }
        }

    }
}
