using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Root_Btn : MonoBehaviour
{
    public GameObject Root;
    public GameObject Root_2;
    public GameObject Root_3;
    public GameManager instance;

    public void Update(){
        if(instance.state == GameState.Event){
            this.GetComponent<Button>().enabled = false;
        }
    }

    public void addRoot()
    {
        Root_2.SetActive(true);
        Debug.Log("Root Added");
        instance.UpdateRoot(1);
    }
}
