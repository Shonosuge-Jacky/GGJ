using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDay_Btn : MonoBehaviour
{
    public GameManager instance;

    public void Update(){
        if(instance.state == GameState.Event){
            this.gameObject.SetActive(false);
        }
    }

    public void ClickedNextDay()
    {
        instance.NextDay();
    }
}
