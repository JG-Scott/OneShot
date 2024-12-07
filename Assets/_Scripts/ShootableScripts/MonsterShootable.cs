using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShootable : Shootable
{
    public GameObject Ragdoll;
    protected override void Interact() {
        Ragdoll.SetActive(true);

        gameObject.SetActive(false);
        

    }
}
