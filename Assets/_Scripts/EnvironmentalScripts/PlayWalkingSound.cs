using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWalkingSound : MonoBehaviour
{

    public float TimeBetween = 1;
    public AudioClip[] walkingSounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeBetween -= Time.deltaTime;
        if(TimeBetween <= 0) {
            TimeBetween = 2;
            GetComponent<AudioSource>().clip  = walkingSounds[Random.Range(0, walkingSounds.Length-1)];
            GetComponent<AudioSource>().Play();
        }
    }
}
