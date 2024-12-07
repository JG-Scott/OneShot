using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public bool hasntShot = true;

    public SoundManager sm;

    public ButtonInteractable bi;

    public LightManager lm;

    public AudioClip click;
    public ParticleSystem flash;

    public Camera cam;

    public int bullet = 1;

    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //get a raycast from the players camera
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 100);    
        RaycastHit hitInfo;


        if(Input.GetMouseButton(0) && bullet > 0 && !GetComponent<AudioSource>().isPlaying) {
            if(Physics.Raycast(ray, out hitInfo, 100, mask)) {
           
            if(hitInfo.collider.GetComponent<Shootable>() != null) {
                hitInfo.collider.GetComponent<Shootable>().BaseInteract();
            }
        }
            bullet -=1;
            flash.Play();
            GetComponent<Animator>().Play("fire");
            GetComponent<AudioSource>().Play();
            sm.CutAllSound();
            lm.endgame();
            bi.locked = true;
        } else if(Input.GetMouseButton(0) && !GetComponent<AudioSource>().isPlaying) {
            GetComponent<AudioSource>().clip = click;
            GetComponent<AudioSource>().Play();
        }
    }
}
