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
    public int sugar;                   //current have geh sugar
    [SerializeField]
    int originalSugar;                  //for storing orginal sugar for reset function(CurrentSuagr will become this one)
    [SerializeField]
    TextMeshProUGUI ToAddSugar;         //text for showing adding sugar
    public GameObject dialog;
    public GameState state;

    [Header("ForReference")]
    private TextAsset inkJSON;
    public GameObject lighting;
    public GameObject NextDayBtn;

    [Header("UI")]
    public TextMeshProUGUI CurrentDay;  //text for showing current day
    public TextMeshProUGUI CurrentLeaf; //text for showing current added Leaf (can be reset)
    public TextMeshProUGUI CurrentRoot; //text for showing current added root (can be reset)
    public TextMeshProUGUI CurrentSugar; //text for showing current sugar (can be change, can can be reset -> originalSugar);
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
        if(DialogueManager.getDialogueManager().dialogueIsPlaying == false){
            inkJSON = (TextAsset) Resources.Load("Dialogue/Day0");
            Debug.Log(inkJSON);
            DialogueManager.getDialogueManager().EnterDialogueMode(inkJSON);
        }
        sugar = 2;
        originalSugar = sugar;
        CurrentSugar.text = sugar.ToString();
    }
    public void UpdateDayRoot(int value){
        if(sugar > 0){
            dayroot+=value;
            CurrentRoot.text = "+" + dayroot;
            sugar --;
            CurrentSugar.text = sugar.ToString();
        }
        
    }
    public void UpdateDayLeaf(int value){
        if(sugar > 0){
            dayleaf+=value;
            CurrentLeaf.text = "+" + dayleaf;
            sugar --;
            CurrentSugar.text = sugar.ToString();
        }
        
    }

    public void UpdateRoot(int value){
        dayroot = 0;
        CurrentRoot.text = "+" + dayroot;
        root += value;
        for(int i = 0; i < root; i++){
            roots[i].enabled = true;
        }
    }
    public void UpdateLeaf(int value){
        dayleaf = 0;
        CurrentLeaf.text = "+" + dayleaf;
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
        sugar = originalSugar;
        CurrentSugar.text = sugar.ToString();
    }

    public void NextDay(){
        if(state == GameState.Planing){
            //from Day to Night
            UpdateGameState(GameState.Event);
            StartCoroutine(lighting.GetComponent<Lighting>().DayToNight());
        }else{

            //from Night to Day
            Debug.Log("DAY: " + day);
            //handle everyday special event and every gv sugar
            switch (day){
                case 1:
                    StartCoroutine(AddSugarEvent(3));
                break;
                case 2:
                    StartCoroutine(AddSugarEvent(3));
                break;
                case 3:
                    StartCoroutine(AddSugarEvent(3));
                break;
                case 4:
                    StartCoroutine(AddSugarEvent(3));
                break;
                case 5:
                    StartCoroutine(AddSugarEvent(3));                
                break;
                case 6:
                    StartCoroutine(AddSugarEvent(3));                
                break;
                case 7:
                    StartCoroutine(AddSugarEvent(3));                
                break;
                case 8:
                    StartCoroutine(AddSugarEvent(3));                
                break;
                case 9:
                    StartCoroutine(AddSugarEvent(3));                
                break;
                case 10:
                
                break;
                case 11:
                
                break;
                case 12:
                
                break;
                case 13:
                
                break;
                case 14:
                
                break;
                case 15:
                
                break;
                default:
                    
                break;
            }
            originalSugar = sugar;
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

    IEnumerator AddSugarEvent(int value){
        Debug.Log("Adding sugar");
        ToAddSugar.gameObject.SetActive(true);
        ToAddSugar.text = "+"+value;
        sugar += value;
        originalSugar = sugar;
        Debug.Log(originalSugar);
        yield return new WaitForSeconds(2f);
        CurrentSugar.text = sugar.ToString();
        ToAddSugar.gameObject.SetActive(false);
    }

}
