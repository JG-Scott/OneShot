using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerLook : MonoBehaviour
{

    public float mouseSens = 375;


    public bool canLook = true;

    public Transform playerBody;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(canLook){

        float mouseX = Input.GetAxis("Mouse X")  * mouseSens*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens*Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up, mouseX);

        }
        if(Input.GetKeyDown(KeyCode.P)) {
            mouseSens+=25;
        }
        if(Input.GetKeyDown(KeyCode.O)) {
            mouseSens-=25;
        }

    }

    public void changeMouseSens(float value) {
        mouseSens = value;
        PlayerPrefs.SetFloat("MouseSens", mouseSens);
    }
}
