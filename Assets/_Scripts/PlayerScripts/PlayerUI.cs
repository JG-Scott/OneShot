using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{   
    [SerializeField]
    private TextMeshProUGUI promptText;

    [SerializeField]
    private TextMeshProUGUI NoteText;

    [SerializeField]
    private GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

    public void ShowNote(string noteText) {
        NoteText.text = noteText;
        StartCoroutine(showForAsecond());
    }

    public void updateImage(Sprite sp, int width, int height) {
        image.GetComponent<Image>().sprite = sp; 
        image.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }
     IEnumerator showForAsecond()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(4);
                NoteText.text = "";
    }   
}
