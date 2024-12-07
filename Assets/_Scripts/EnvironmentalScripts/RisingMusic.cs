using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingMusic : MonoBehaviour
{

    public AudioSource music;

    public AudioSource heartBeat;

    public float musicSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        music.volume+=Time.deltaTime * musicSpeed;
    }


    public void stop() {
        music.Stop();
    }

    public void PlayHeartBeat() {
        if(!heartBeat.isPlaying)
            heartBeat.Play();
    }

}
