using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletInteractable : Interactable
{

    public bool locked = false;

    public Light lm;
    public Animator box;
    public PlayerUI pui;

    public FireGun fg;
    protected override void Interact()
    {

        locked = true;
        
        lm.enabled = false;

        box.Play("close");

        pui.ShowNote("Another bullet.<br>This should come in handy.");
        gameObject.layer = LayerMask.NameToLayer("Default");
        GetComponent<MeshRenderer>().enabled = false;
        fg.bullet+=1;
        Debug.Log("Button Pressed");
    }
}
