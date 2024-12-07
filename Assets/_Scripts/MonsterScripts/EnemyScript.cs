using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public Transform[] positions;
    public int index;

    public bool hasBeenSeenOnce; 

    public bool headHasTurned;

    public bool LightsAreOff;

    public bool playerIsNotLooking;
    public float CurrentTimeBetweenMoves;

    public LightManager lm;
    public PlayerInteract playerInteract;

    public RotateTowardsPlayer rotateTowardsPlayer;
    float OriginalTimeBetweenMove;

    bool onetime = true;
    bool onetime2 = true;

    bool onetime3 = true;

    public bool doneTalking;

    public float lightOffFactor;
    // Start is called before the first frame update
    void Start()
    {
        OriginalTimeBetweenMove = CurrentTimeBetweenMoves;
    }

    // Update is called once per frame
    void Update()
    {
        if(doneTalking && onetime3)
            StartCoroutine(waitfor15beforestarting());

        LightsAreOff = !lm.lightsOn;
        Debug.Log(LightsAreOff);
        if(lm.end && onetime2) {
            onetime2 = false;
            OriginalTimeBetweenMove = 5;
            CurrentTimeBetweenMoves = 5;
        }

        playerIsNotLooking = !playerInteract.isLookingForward;
        lightOffFactor = 1.5f;
        if(!LightsAreOff) {
            hasBeenSeenOnce = true;
            lightOffFactor = 0.75f;
        }
        Debug.Log(hasBeenSeenOnce);
        Debug.Log(headHasTurned);

        if(LightsAreOff && hasBeenSeenOnce && !headHasTurned) {
            rotateTowardsPlayer.rotate();
            headHasTurned = true;

        }

        if(hasBeenSeenOnce && headHasTurned) {
            CurrentTimeBetweenMoves-= Time.deltaTime * lightOffFactor;
            if(CurrentTimeBetweenMoves <= 0) {
                if(LightsAreOff || playerIsNotLooking) {
                    moveToNextPosition();
                    CurrentTimeBetweenMoves = OriginalTimeBetweenMove;
                }
            }
        }
    }

    public void moveToNextPosition() {
        if(onetime) {
            if(index >= positions.Length) {
                GameManager.gm.setState(GameManager.GameState.LET_THE_DUMMY_GET_TO_CLOSE);
                onetime = false;
            } else {    
                transform.position = positions[index].position;
                transform.eulerAngles = positions[index].eulerAngles;
                index++;
                GetComponent<SoundManager>().playRustling();
            }

        }
    }

    public IEnumerator waitfor15beforestarting() {
        onetime3 = false;
        yield return new WaitForSeconds(15);
        hasBeenSeenOnce = true;
        rotateTowardsPlayer.rotate();
        headHasTurned = true;
    }
}
