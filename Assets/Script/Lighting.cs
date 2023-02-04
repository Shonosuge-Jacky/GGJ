using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lighting : MonoBehaviour
{
    public GameManager instance;
    private Image image;

    private void Awake() {
        image = GetComponent<Image>();
    }
    public IEnumerator DayToNight(){
        for(float i = 0f; i <= 0.8f; i += 0.02f){
            Color c = this.GetComponent<Image>().color;
            c.a = i;
            this.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.05f);
            
        }
        instance.HandleEvent();
    }

    public IEnumerator NightToDay(){
        Debug.Log("---");
        for(float i = 0.8f; i >= 0f; i -= 0.02f){
            Color c = this.GetComponent<Image>().color;
            c.a = i;
            this.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.05f);
            
        }
        instance.HandlePlaning();
    }
}
