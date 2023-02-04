using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset_Btn : MonoBehaviour
{
    public GameManager instance;

    public void Update(){
        if(instance.state == GameState.Event && this.gameObject.activeSelf){
            StartCoroutine(DisableItself());
        }
    }

    IEnumerator DisableItself(){
        this.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }

    public void ClickedReset()
    {
        instance.ResetNum();
    }
}
