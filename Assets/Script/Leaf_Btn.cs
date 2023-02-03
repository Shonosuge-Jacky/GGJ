using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaf_Btn : MonoBehaviour
{
    public GameObject Leaf;
    public GameManager instance;

    public void Update(){
        if(instance.state == GameState.Event){
            this.GetComponent<Button>().enabled = false;
        }else{
            this.GetComponent<Button>().enabled = true;
        }
    }

    public void addLeaf()
    {
        Leaf.SetActive(true);
        Debug.Log("Leaf Added");
        instance.UpdateLeaf(1);
    }
}
