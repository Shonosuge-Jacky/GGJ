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
    public GameState state;
    [Header("ForReference")]
    private TextAsset inkJSON;
    public GameObject lighting;
    public GameObject NextDayBtn;
    [Header("Data")]
    public Text CurrentDay;
    public Text CurrentLeaf;
    public Text CurrentRoot;


  

    void Awake(){
        instance = this;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.Planing);
        CurrentDay.text = "Day "+ day;
    }

    public void UpdateRoot(int value){
        root += value;
    }
    public void UpdateLeaf(int value){
        leaf += value;
    }

    public void NextDay(){
        if(state == GameState.Planing){
            UpdateGameState(GameState.Event);
            StartCoroutine(lighting.GetComponent<Lighting>().DayToNight());

        }else{
            StartCoroutine(lighting.GetComponent<Lighting>().NightToDay());
        }
        
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

    public void HandleEvent(){
        if(DialogueManager.getDialogueManager().dialogueIsPlaying == false){
            inkJSON = (TextAsset) Resources.Load("Dialogue/Day" + day.ToString());
            Debug.Log(inkJSON);
            DialogueManager.getDialogueManager().EnterDialogueMode(inkJSON);
        }
        day++;
    }

    public void HandlePlaning(){
        UpdateGameState(GameState.Planing);
        CurrentDay.text = "Day "+day;
        NextDayBtn.SetActive(true);
    }
}
