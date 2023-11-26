using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutUI : MonoBehaviour
{
    public GameObject nextScript;
    public Canvas _canvas;
    public Sprite[] CutImage;
    public Image cut;
    public int cutIndex;
    public bool ok = true;

    Animator cut_anim;

    private void Awake()
    {
        cut_anim = _canvas.GetComponent<Animator>();
    }

    public void CutAppear()
    {
        Debug.Log("ÄÆ¾À µîÀå " + cutIndex);
        ok = false;
        cut.sprite = CutImage[cutIndex];
        cut_anim.SetBool("Start", true);
    }

    public void CutDisappear()
    {
        cut_anim.SetBool("Start", false);
        nextScript.SetActive(true);
        ok = true;
    }
}
