using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private Story currentStory;  //ink package
    public bool dialogueIsPlaying;
    private static DialogueManager dialogueManager;


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

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        if(currentStory.canContinue){
            dialogueText.text = currentStory.Continue();
        }else{
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode(){
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

}
