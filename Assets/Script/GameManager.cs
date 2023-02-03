using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState{
    Planing,
    Event
}

public class GameManager : MonoBehaviour
{
    public GameManager instance;
    [SerializeField]
    int day;
    [SerializeField]
    int root;
    [SerializeField]
    int leaf;
    public GameObject dialog;
    
    private TextAsset inkJSON;

    public GameState state;

    void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.Planing);
    }

    public void UpdateRoot(int value){
        root += value;
    }
    public void UpdateLeaf(int value){
        leaf += value;
    }

    public void NextDay(){
        UpdateGameState(GameState.Event);
        StartCoroutine(DayTransition());
    }

    IEnumerator DayTransition(){
        Debug.Log("change light");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("change light done");
        HandleEvent();
    }

    // Update is called once per frame

    void UpdateGameState(GameState gameState){
        state = gameState;
        switch(gameState){
            case GameState.Planing:
                break;
            case GameState.Event:
                break;
        }
    }

    void HandleEvent(){
        day++;
        if(DialogueManager.getDialogueManager().dialogueIsPlaying == false){
            inkJSON = (TextAsset) Resources.Load("Dialogue/Day" + day.ToString());
            Debug.Log(inkJSON);
            DialogueManager.getDialogueManager().EnterDialogueMode(inkJSON);
        }
    }
}
