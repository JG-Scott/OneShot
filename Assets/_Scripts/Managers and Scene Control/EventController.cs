using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    // on of the manequins will turn there head to face the player

    public GameObject arm;
    public void turnHead() {
        arm.GetComponent<Rigidbody>().isKinematic = false;
        arm.GetComponent<AudioSource>().Play();

    }
    

    // one of the mannequins will vanish while the lights are off
    public void vanish() {}


    // one of the manequins arms will fall off causeing a loud noise
    public void armFallOff() {}


    // while the lights are off a mannaquin will be taken to the rafters
    // it will be able to be seen by its sillouette passing holes in the wall
    public void pickedUpToTheRafters() {}

    // if picked up is played, a small amount of time later the manaquin will drop from the cieling close to the player.
    public void dropFromRafters() {}

    


}
