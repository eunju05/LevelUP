using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStart : MonoBehaviour
{
    public GameObject nextScript;
    
    public void Next()
    {
        nextScript.SetActive(true);
    }
}
