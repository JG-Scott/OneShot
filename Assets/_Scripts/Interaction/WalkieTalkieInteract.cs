using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WalkieTalkieInteract : Interactable
{
    public bool locked = false;

    public walkieTalkiePulse wp;

    public MeshRenderer screenLight;
    public Material screenOff;
    public Material screenOn;

    public string[] dialogue;

    public string[] dialouge2;

    public AudioClip[] dialogueSounds;
    private int index;


    public GameObject buzz;

    public TMP_Text textArea;

    public GameObject monster;

    public SoundManager sm;
    public DropArm da;

    public EnemyScript es;

    bool isEndGame = false;
    protected override void Interact()
    {
        if(locked) {
            screenLight.material = screenOff;
            buzz.SetActive(false);
            return;
        }
        wp.stopPulse();
        buzz.SetActive(true);
        screenLight.material = screenOn;
        Debug.Log("walkie talkie pressed");
        textArea.text = dialogue[index];
        GetComponent<AudioSource>().clip = dialogueSounds[index];
        GetComponent<AudioSource>().Play();
        index++;
        if(index>=dialogue.Length) {
            StartCoroutine(lastWord());
        }
    }
    
    IEnumerator lastWord() {
        gameObject.layer = LayerMask.NameToLayer("Default");
        if(isEndGame)
             monster.SetActive(true);
        yield return new WaitForSeconds(1);
        textArea.text = "";
        locked = true;
        screenLight.material = screenOff;
        buzz.SetActive(false);
        es.doneTalking = true;
        sm.doneTalking = true;
        da.doneTalking = true;
        if(!isEndGame) {
            GameManager.gm.setState(GameManager.GameState.AFTER_FIRST_DIALOGUE);
        }
    
    }

    public void nextMessage() {
        wp.startPulse();
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        index = 0;
        isEndGame = true;
        dialogue = dialouge2;
        locked=false;
    }
}
