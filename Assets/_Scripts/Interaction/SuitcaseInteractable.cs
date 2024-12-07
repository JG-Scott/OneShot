using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseInteractable : Interactable
{
    public bool locked = false;

    public Animator hinge;

    public PlayerUI pui;

    public PlayerController pc;

    public GameObject playerSuitcaseHolder;
    bool firstTime = true;
    protected override void Interact()
    {
        if(locked) {
            var audio = GetComponent<AudioSource>();
            if(!audio.isPlaying)
                audio.Play();
            return;
        }
        if(firstTime) {
            pui.ShowNote("'r' to exit.");
            firstTime = false;
        }
        pc.setState(PlayerController.States.SUITCASE);
        GetComponent<AudioSource>().Play();
        foreach (var item in GetComponentsInChildren<MeshRenderer>())
        {
            item.enabled = false;
        }
        locked = true;
        gameObject.layer = LayerMask.NameToLayer("Default");
        Debug.Log("Button Pressed");
    }


    public void unlock() {
        hinge.Play("open");
        gameObject.layer = LayerMask.NameToLayer("Suitcase");
    }


    public void reset() {
        
        foreach (var item in GetComponentsInChildren<MeshRenderer>())
        {
            item.enabled = true;
        }
        locked = false;
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }
}
