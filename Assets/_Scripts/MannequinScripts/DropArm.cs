using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArm : MonoBehaviour
{

    public float time;

    public bool onetime= true;

    public bool doneTalking;
    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(15, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if(onetime) {
            if(doneTalking)
                time-=Time.deltaTime;

        if(time <=0) {
            onetime = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<AudioSource>().Play();
        }

        }
    }
}
