using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField]
    private float distance = 3;
    [SerializeField]
    private LayerMask mask;

    public bool isLookingForward;

    ////private PlayerUI playerUI;

    [SerializeField]
    Sprite basic;


    [SerializeField]
    Sprite hand;

    [SerializeField]
    Camera cam;

    PlayerUI playerUI;

    [SerializeField] 

    // Start is called before the first frame update
    void Start()
    {
       playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerUI.UpdateText(string.Empty); // set the Interact note to empty every frame


        playerUI.updateImage(basic, 20, 20); // set the middle cursor every frame along with size

        //get a raycast from the players camera
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);    
        RaycastHit hitInfo;

        isLookingForward= false;
        if(Physics.Raycast(ray, out hitInfo, distance, mask)) {
           
            if(hitInfo.collider.GetComponent<Interactable>() != null) {

                handleUIChange(hitInfo);
                HandleInteractInput(hitInfo);
            } else {
                 HandleNonInteractInput();
            }
        }

    }

    private void handleUIChange(RaycastHit hitInfo){

        playerUI.updateImage(hand, 30, 30);
        if(hitInfo.collider.GetComponent<Interactable>().promptMessage != string.Empty) {
           // playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
        }
    }

    private void HandleInteractInput(RaycastHit hitInfo) {
        // if(hitInfo.collider.GetComponent<ToggleOutlineScript>() && !hitInfo.collider.GetComponent<ToggleOutlineScript>().checkIsOn()) {
        //         currentObj = hitInfo.collider.GetComponent<ToggleOutlineScript>();
        //         currentObj.setOutline(true);
        // }
        if(Input.GetKeyDown(KeyCode.E)){
            hitInfo.collider.GetComponent<Interactable>().BaseInteract();
            if(hitInfo.collider.GetComponent<Interactable>().NoteMessage != string.Empty) {
                //playerUI.ShowNote(hitInfo.collider.GetComponent<Interactable>().NoteMessage);
            }
        }

    }

    private void HandleNonInteractInput() {
        isLookingForward = true;
    }
}
