using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public enum GameState {START, AFTER_FIRST_DIALOGUE, A_SHOT_AND_A_MISS, DUMMY_SHOT, LET_THE_DUMMY_GET_TO_CLOSE, MONSTER_KILL_SCENE, LIGHTS_OUT}

    public GameState currentState = GameState.START;

    public static GameManager gm;



    // interactable game objects
    public GameObject walkietalkie;
    public GameObject gun;
    public GameObject button;
    public GameObject suitcase;
    public GameObject bullet;
    public Camera playerCam;
    public Camera deathCam;
    public GameObject EnemyKillAnim;

    public string nameOfEndScreen;

public WalkieTalkieInteract Walkitalkieinteract;
    public GameObject EnemyDummyHolder;

    public GameObject dummy;

    public SoundManager sm;

    public GameObject hands;

    public GameObject forwardCheck;
    

    public float dummyTime = 5;

    public AudioSource SpookyMusic;
public bool test;


    bool dummyCountDownStart = false;

    bool cancelled = false;

    public AudioMixer am;



    // Start is called before the first frame update
    void Start()
    {
        if(gm == null) {
            gm = this;
        }
        setState(GameState.START);
    }

    // Update is called once per frame
    void Update()
    {
        if(!cancelled) {
            if(SpookyMusic.isPlaying) {
                dummyCountDownStart = true;
            }

            if(dummyCountDownStart){
                dummyTime -= Time.deltaTime;
                if(dummyTime <=0) {
                    hands.SetActive(true);
                }
            }


            if(Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene("MainMenu");
            }

        }

        if(Input.GetKeyDown(KeyCode.K)) {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }


    }
    

    public void setState(GameState state) {
        switch(state) {
            case GameState.START:
                gun.layer = LayerMask.NameToLayer("Default");
                button.layer = LayerMask.NameToLayer("Default");
                suitcase.layer = LayerMask.NameToLayer("Default");
                bullet.layer = LayerMask.NameToLayer("Default");    
            break;
            case GameState.AFTER_FIRST_DIALOGUE:
                gun.layer = LayerMask.NameToLayer("Interactable");
                button.layer = LayerMask.NameToLayer("Interactable");
                suitcase.layer = LayerMask.NameToLayer("Interactable");
                bullet.layer = LayerMask.NameToLayer("Interactable");    
            break;
            case GameState.A_SHOT_AND_A_MISS:
                 suitcase.layer = LayerMask.NameToLayer("Default");
                 //silence for a few seconds
                 //start playing rustling sounds/
                // layer inscary music
                //running footsteps
                //trigger arms

            break;
            case GameState.LET_THE_DUMMY_GET_TO_CLOSE:
                suitcase.layer = LayerMask.NameToLayer("Default");
                if(!SpookyMusic.isPlaying)
                    SpookyMusic.Play();

            break;  
            case GameState.DUMMY_SHOT:
                suitcase.layer = LayerMask.NameToLayer("Default");
                if(SpookyMusic.isPlaying) {
                        SpookyMusic.Stop();
                        hands.SetActive(false);
                        dummyCountDownStart = false;
                        cancelled = true;
                }
                gun.layer = LayerMask.NameToLayer("Default");
                button.layer = LayerMask.NameToLayer("Default");
                suitcase.layer = LayerMask.NameToLayer("Default");
                bullet.layer = LayerMask.NameToLayer("Default");
                forwardCheck.SetActive(false);

                StartCoroutine(waitThenWalkieTalkie());


            break;  
            case GameState.MONSTER_KILL_SCENE:
                playerCam.enabled = false;
                deathCam.enabled = true;
                EnemyKillAnim.SetActive(true);
                EnemyKillAnim.GetComponent<ChangeSceneAfterSound>().sceneToLoad = nameOfEndScreen;
                gun.SetActive(false);
                //playsoundEffect
            break;  
            case GameState.LIGHTS_OUT:
                if(currentState != GameState.DUMMY_SHOT) {
                    EnemyDummyHolder.SetActive(true);
                    EnemyKillAnim.GetComponent<ChangeSceneAfterSound>().sceneToLoad = nameOfEndScreen;
                    dummy.SetActive(false);
                    sm.CutAllSound();
                }
                //playsoundEffect
            break;  
        }

                currentState = state;
    }

    public IEnumerator waitThenWalkieTalkie() {
        yield return new WaitForSeconds(2f);
         Walkitalkieinteract.nextMessage();
    }
}
