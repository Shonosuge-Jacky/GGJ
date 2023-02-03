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
        UpdateGameState(GameState.Event);
    }
    public void UpdateLeaf(int value){
        leaf += value;
        UpdateGameState(GameState.Event);
    }

    // Update is called once per frame

    void UpdateGameState(GameState gameState){
        state = gameState;
        switch(gameState){
            case GameState.Planing:
                break;
            case GameState.Event:
                HandleEvent();
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
