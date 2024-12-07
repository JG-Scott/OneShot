using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractable : Interactable
{
    public bool locked = false;

    public LightManager lm;
    protected override void Interact()
    {
        if(locked) {
            var audio = GetComponent<AudioSource>();
            if(!audio.isPlaying)
                audio.Play();
            return;
        }
        locked = true;
        lm.TurnOnLights();
        Debug.Log("Button Pressed");
    }
}
