using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRetreatAnimation : MonoBehaviour
{

    public float time;

    public float time2;
    public Animator anim;

    public bool retreatPlayed;

    bool onetime = true;
    public GameObject RunningSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<PlayWalkingSound>().enabled) {
            time -= Time.deltaTime;
            if(time <= 0) {
                anim.Play("Retreat");
                GetComponent<RisingMusic>().stop();
                GetComponent<RisingMusic>().PlayHeartBeat();
                retreatPlayed = true;
            }
        }

        if(retreatPlayed) {
            time2-=Time.deltaTime;
            if(time2 <= 0 && onetime) {
                onetime=false;
                RunningSound.SetActive(true);
            }
            if(!onetime && !RunningSound.GetComponent<AudioSource>().isPlaying) {
                GameManager.gm.nameOfEndScreen = "EndScreen2";
                GameManager.gm.setState(GameManager.GameState.MONSTER_KILL_SCENE);
            }
        }   
     }
}
