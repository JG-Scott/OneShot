using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fallApart : MonoBehaviour
{

    public GameObject[] Parts;
    bool hasFallenApart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision col) {
        if(col.gameObject.layer == LayerMask.NameToLayer("Table")) {
            if(!hasFallenApart) {
                foreach (var item in Parts)
                {
                    item.AddComponent<Rigidbody>();
                    item.transform.parent = null;
                }

            }
            
        }
    }   
}
