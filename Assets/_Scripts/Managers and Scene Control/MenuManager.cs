using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine.Audio;
public class MenuManager : MonoBehaviour
{

    public GameObject mainCanvas;
    public GameObject settingsCanvas;
    public GameObject creditsCanvas;

    public AudioMixer master;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        if( PlayerPrefs.GetFloat("Volume") != 0)
            master.SetFloat("MasterVolume", math.log10(PlayerPrefs.GetFloat("Volume"))*20);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backToMainMenu() {
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
    }
    public void ExitGame() {
        Application.Quit();
    }

    public void openSettings() {
        mainCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
        creditsCanvas.SetActive(false); 
    }

    public void openCredits() {
                mainCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void startGame() {
        SceneManager.LoadScene("The shed");
    }


}
