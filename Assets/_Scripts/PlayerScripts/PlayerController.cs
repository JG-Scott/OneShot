using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public enum States {NORMAL, GUN, CUTSCENE, SUITCASE};

    public GameObject gun;
    public RevolverInteract ri;
    public GameObject suitcase;

    public SuitcaseInteractable si;

    public WalkieTalkieInteract walkie;

    public GameObject arms;


    public AudioSource gunAudio;

    public AudioSource suitcaseAudio;

    public PlayerLook pl;
    public States currentState;
    // Start is called before the first frame update
    void Start()
    {
        setState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState) {
            case States.NORMAL:
            
            break;
            case States.GUN:
               if(Input.GetKeyDown(KeyCode.R)) {
                setState(States.NORMAL);
               }
            break;
            case States.CUTSCENE:
            break;

            case States.SUITCASE:
            if(Input.GetKeyDown(KeyCode.R)) {
                setState(States.NORMAL);
            }
            break;
        }

    //     if(Input.GetKeyDown(KeyCode.A)) {
    //             arms.SetActive(true);
    //             GetComponent<AudioSource>().Play();
    //    }
    //     if(Input.GetKeyDown(KeyCode.D)) {
    //         walkie.nextMessage();
    //    }
    }

    public void setState(States state) {
        States prevState = currentState;
        currentState = state;
        HandleStateSwitch(prevState);
    }

    public void HandleStateSwitch(States prevState) {
        switch(currentState) {
            case States.NORMAL:
                pl.canLook = true;

                if(prevState == States.GUN)  {
                    ri.reset();
                    gun.SetActive(false);
                    gunAudio.Play();
                }   
                if(prevState == States.SUITCASE)  {
                   si.reset();
                   Cursor.lockState = CursorLockMode.Locked;
                   suitcaseAudio.Play();
                   suitcase.SetActive(false);
                }   
            break;
            case States.GUN:
                gun.SetActive(true);
            break;
            case States.CUTSCENE:
            break;
            case States.SUITCASE:
            if(prevState == States.GUN)  {
                    ri.reset();
                    gun.SetActive(false);
                    gunAudio.Play();
                }   
            pl.canLook = false;
            suitcase.SetActive(true);
             Cursor.lockState = CursorLockMode.None;
            break;
        }
    } 


}
