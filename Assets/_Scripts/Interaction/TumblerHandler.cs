using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumblerHandler : MonoBehaviour
{

    public int currentNumber;

    public SuitcaseHandler sch;

    public AudioSource click;
    public float curRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        curRotation = transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tumble() {
        click.Play();
        curRotation -= 36;
        transform.localEulerAngles = new Vector3(curRotation, 0f, 0f);
        currentNumber+=1;
        if(currentNumber>9) 
            currentNumber = 0;
        
        sch.checkCode();
    }
}
