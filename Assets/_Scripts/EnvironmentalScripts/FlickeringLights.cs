using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    public bool lightsOn = false;
    public float timeDelay = 0.3f;
    // Update is called once per frame
    void Update()
    {
        timeDelay -= Time.deltaTime;
        if(timeDelay <= 0) {
            if(!lightsOn){
                timeDelay = Random.Range(0.01f, 0.2f);
                lightsOn = true;
            } else {
                timeDelay = Random.Range(0.2f, 0.8f);
                lightsOn = false;
            }

            var lights = GetComponentsInChildren<Light>();
            foreach(var l in lights) {
                l.enabled = !l.enabled;
            }
        }
    }
}
