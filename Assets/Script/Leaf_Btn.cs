using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf_Btn : MonoBehaviour
{
    public GameObject Leaf;

    public void addLeaf()
    {
        Leaf.SetActive(true);
        Debug.Log("Leaf Added");
    }
}
