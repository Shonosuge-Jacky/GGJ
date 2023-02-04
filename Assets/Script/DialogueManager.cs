using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private float typingSpeed = 0.04f;
    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine = false;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private Story currentStory;  //ink package
    public bool dialogueIsPlaying;
    private static DialogueManager dialogueManager;
    public GameManager instance;
    private bool IsignoreTyping;
    private bool IntroEnd = false;


    void Awake() {
        if (dialogueManager != null){
            Debug.Log("More then one dialogueManager.");
        }
        dialogueManager = this;
    }

    public static DialogueManager getDialogueManager(){
        return dialogueManager;
    }

    private void Start() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }
    private void Update() {
        if(!dialogueIsPlaying){
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space) && canContinueToNextLine == true){
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();

    }

    private IEnumerator DisplayLine(string line){
        dialogueText.text = "";
        canContinueToNextLine = false;
        foreach(char letter in line.ToCharArray()){
            if(letter == '<' || IsignoreTyping){
                IsignoreTyping = true;
            }else{
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            if(IsignoreTyping && letter == '>'){
                IsignoreTyping = false;
            }
            
        }
        canContinueToNextLine = true;
    }

    private void ExitDialogueMode(){
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        if(IntroEnd){
            instance.NextDay();
        }else{
            IntroEnd = true;
        }
    }

    private void ContinueStory(){
        if(currentStory.canContinue ){
            if(displayLineCoroutine != null){
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
        }else{
            ExitDialogueMode();
        }
    }

}
