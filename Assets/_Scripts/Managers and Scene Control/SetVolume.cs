using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SetVolume : MonoBehaviour
{

    public AudioMixer master;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void setVolume(float value) {
         master.SetFloat("MasterVolume", math.log10(value)*20);
         PlayerPrefs.SetFloat("Volume", value);
    }
}

