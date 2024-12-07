using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{

    public int numberOfLightPresses = 5;

    public float lightOnTime = 5f;

    public float orignalLightOnTime;

    public bool lightsOn;
    public bool end = false;
    public ButtonInteractable button;


    public AudioSource[] sources;

    public ParticleSystem[] particles;

    public GameObject[] lightObjects;

    public int index = 0;

    float timeToWait = 3;
    public GameObject lightHolder;

    public FireGun gun;

    public SoundManager sm;

    public bool oneTime = true;
    // Start is called before the first frame update
    void Start()
    {
        orignalLightOnTime = lightOnTime;
    }

    public void TurnOnLights() {
        lightsOn = true;
        lightHolder.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfLightPresses <= 0) 
            end = true;
        if(!end) {

            if(!lightsOn){
                button.locked = false;
                lightHolder.SetActive(false);
                return;
            }

            lightOnTime -= Time.deltaTime;

            if(lightOnTime <=0) {
                lightOnTime = orignalLightOnTime;
                numberOfLightPresses--;
                lightsOn = false;
                if(numberOfLightPresses <= 2) {
                    sources[index].Play();
                    particles[index].Play();
                    Destroy(lightObjects[index]);
                    index++;
                }
            }
        } else {
                
            lightHolder.SetActive(false);
            sm.CutAllSound();
            timeToWait -= Time.deltaTime;
            if(oneTime && timeToWait <=0) {
                oneTime = false;
                if(gun.bullet == 0){
                    GameManager.gm.setState(GameManager.GameState.LIGHTS_OUT);
                }
            }
        }
            
    }

    public void endgame() {
        end = true;
    }
}
