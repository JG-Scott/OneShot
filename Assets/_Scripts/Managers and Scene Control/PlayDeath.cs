using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDeath : MonoBehaviour
{


    public PlayerInteract playerInteract;
    public bool onetime = true;
    public string nameOfEndScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInteract.isLookingForward && onetime) {
            onetime = false;
            GetComponent<Animator>().Play("reach");
        }
    }

    public void playDeath() {
        GameManager.gm.nameOfEndScreen = nameOfEndScreen;
        GameManager.gm.setState(GameManager.GameState.MONSTER_KILL_SCENE);
    }
}
