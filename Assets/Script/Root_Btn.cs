using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root_Btn : MonoBehaviour
{
    public GameObject Root;
    public GameObject Root_2;
    public GameObject Root_3;

    public void addRoot()
    {
        Root_2.SetActive(true);
        Debug.Log("Root Added");
    }
}
