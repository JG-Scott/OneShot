using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backToMain() {
        SceneManager.LoadScene("MainMenu");
    }
}
