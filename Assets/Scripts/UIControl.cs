using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    Animator UI_anim;
    void Awake()
    {
        UI_anim = GetComponent<Animator>();
    }
    
    public void UIAppear()
    {
        UI_anim.SetBool("isWorld", true);
    }

    public void UIMove()
    {
        UI_anim.SetBool("Appear_Finish", true);
    }

    public void UIStage()
    {
        UIAppear();
        Invoke("UIMove", 1f);
    }
}
