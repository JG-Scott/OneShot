using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseHandler : MonoBehaviour
{
    public PlayerController pc;

    public TumblerHandler t1;
    public TumblerHandler t2;
    public TumblerHandler t3;

    public AudioSource choirSound;
    public AudioSource lightClickSound;
    public AudioSource openSound;
    public AudioSource unlockSound;

    public GameObject man;
    public GameObject pusher;

    
    public Light l;
    public int code1;
    public int code2;
    public int code3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void checkCode() {
        if(t1.currentNumber == code1)
            if(t2.currentNumber == code2)
                if(t3.currentNumber == code3) {
                    // its open deal with it
                    pc.setState(PlayerController.States.NORMAL);
                    //reset suitcase
                    
                    GetComponent<SuitcaseInteractable>().reset();
                    GetComponent<SuitcaseInteractable>().unlock();
                    // man.SetActive(true);
                    // pusher.SetActive(true);
                    //call open on suitcase
                }
    }


    public void flipLight() {
        l.enabled = true;
        //choirSound.Play();
    }

    public void playChoirSound() {
        choirSound.Play();  
    }

    public void playUnlockSound() {
        unlockSound.Play();
    }
    public void playOpenSound() {
        openSound.Play();
    }   
    public void playLightClickSound() {
        lightClickSound.Play();
    }
}
