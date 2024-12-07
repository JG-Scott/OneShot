using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool tempStopAllSounds;

    public AudioSource spookyLayer;
    public AudioSource[] soundLocations;
    public AudioClip[] rustleSounds;

    public bool doneTalking = false;

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Q))
        //     playRustling();
        
        // if(Input.GetKeyDown(KeyCode.W))
        //     layerSpooky();

        if(doneTalking)
            time -= Time.deltaTime;

        if(time <0) {
            time = 100000;
            layerSpooky();
        }

    }

    public void CutAllSound(){ 
        var sounds = GetComponentsInChildren<AudioSource>();
        foreach (var item in sounds)
        {
            item.Stop();
        }
        GetComponent<AudioSource>().Stop();
    }

    public void layerSpooky() {
        if(spookyLayer !=null)
            spookyLayer.Play();
    }

    public void playRustling() {
        int location = Random.Range(0, soundLocations.Length);
        int sound = Random.Range(0, rustleSounds.Length);

        soundLocations[location].clip = rustleSounds[sound];
        soundLocations[location].Play();
    }
}
