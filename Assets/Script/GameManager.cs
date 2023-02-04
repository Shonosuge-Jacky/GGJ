using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField]
    int dayroot;
    [SerializeField]
    int dayleaf;
    public GameObject dialog;
    public GameState state;


    [Header("ForReference")]
    private TextAsset inkJSON;
    public GameObject lighting;
    public GameObject NextDayBtn;

    [Header("UI")]
    public TextMeshProUGUI CurrentDay;
    public TextMeshProUGUI CurrentLeaf;
    public TextMeshProUGUI CurrentRoot;
    public Image[] leaves;
    public Image[] roots;
  
    void Awake(){
        instance = this;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.Planing);
        CurrentDay.text = "Day "+ day;
    }
    public void UpdateDayRoot(int value){
        dayroot+=value;
        CurrentRoot.text = "+" + dayroot;
    }
    public void UpdateDayLeaf(int value){
        dayleaf+=value;
        CurrentLeaf.text = "+" + dayleaf;
    }

    public void UpdateRoot(int value){
        root += value;
        for(int i = 0; i < root; i++){
            roots[i].enabled = true;
        }
    }
    public void UpdateLeaf(int value){
        leaf += value;
        for(int i = 0; i < leaf; i++){
            leaves[i].enabled = true;
        }
    }

    public void ResetNum(){
        dayleaf = 0;
        dayroot = 0;
        CurrentRoot.text = "+" + dayroot;
        CurrentLeaf.text = "+" + dayleaf;
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
        // switch(gameState){
        //     case GameState.Planing:
        //         break;
        //     case GameState.Event:
        //         break;
        // }
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
        UpdateLeaf(dayleaf);
        UpdateRoot(dayroot);
        CurrentDay.text = "Day "+day;
        NextDayBtn.SetActive(true);
    }

}
