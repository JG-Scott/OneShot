using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DummyShootable : Shootable
{

    public GameObject enemy;

    public RisingMusic rm;

    public GameObject ragdoll;
    public GameObject[] parts; 
     protected override void Interact()
    {
        if(GetComponent<Rigidbody>() !=null)
            GetComponent<Rigidbody>().isKinematic = false;
        if(GetComponent<BoxCollider>() !=null)
            GetComponent<BoxCollider>().enabled = false;
        if(GetComponent<MeshCollider>() !=null)
            GetComponent<MeshCollider>().enabled = true;
        if(GetComponent<EnemyScript>() !=null) {
            GetComponent<EnemyScript>().enabled = false;
            GameManager.gm.setState(GameManager.GameState.DUMMY_SHOT);
        } else {
            enemy.SetActive(false);
            ragdoll.SetActive(true);
            rm.enabled = false;
        }
    
                foreach (var item in parts)
                {
                    item.AddComponent<Rigidbody>();
                    item.transform.parent = null;
                }
    }
}
