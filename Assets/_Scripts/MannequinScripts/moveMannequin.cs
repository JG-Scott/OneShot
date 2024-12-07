using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class moveMannequin : MonoBehaviour
{
    public GameObject player;

    public bool enemyMove = false;

    public float speed;

    public float distance;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyMove) {
            if(Vector3.Distance(transform.position, player.transform.position) > distance) {
             transform.position -= Vector3.forward*Time.deltaTime* speed;
            } else {
                GetComponent<PlayWalkingSound>().enabled = false;
            }
        } else {
            transform.position -= Vector3.forward*Time.deltaTime * speed;
        }
    }
}
