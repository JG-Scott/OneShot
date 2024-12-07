using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSensitivity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("MouseSens");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
