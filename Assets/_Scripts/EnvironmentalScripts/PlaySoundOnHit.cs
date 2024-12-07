using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnHit : MonoBehaviour
{

    public LayerMask ignoreLayer;
    bool one_time= true;
    public int numTimes = 2;
    public bool timedPlay;

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(one_time) {
        
        if(!timedPlay){
            if(numTimes <= 0) {
                one_time = false;
            }        
        } else {
            time -= Time.deltaTime;
            if(time <= 0) {
               GetComponent<AudioSource>().Play();  
               one_time = false;
            }
        }
        }
    }

    public void OnCollisionEnter(Collision col) {

        if(one_time)
            if(col.gameObject.layer != ignoreLayer) {
                GetComponent<AudioSource>().Play();   
                numTimes--;
            }
    }

}
