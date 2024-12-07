using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverInteract : Interactable
{
    public bool locked = false;

    public bool firstTime = true;

    public PlayerController pc;

    public PlayerUI pui;

    public FireGun gun;

    protected override void Interact()
    {
        if(locked) {
            return;
        }
        if(firstTime) {
            if(gun.bullet >= 2) {
                pui.ShowNote("'r' to drop.<br>Left mouse to fire.<br>You got two shots.");

            } else {
                pui.ShowNote("'r' to drop.<br>Left mouse to fire.<br>You only have one shot.");
            }
            firstTime = false;
        }
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<AudioSource>().Play();
        gameObject.layer = LayerMask.NameToLayer("Default");
        pc.setState(PlayerController.States.GUN);
        Debug.Log("Button Pressed");
    }

    public void reset(){
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        GetComponent<MeshRenderer>().enabled = true;
    }
}
