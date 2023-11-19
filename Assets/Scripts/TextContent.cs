using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextContent : MonoBehaviour
{
    public GameObject Lumine_TalkPanel;
    public GameObject Venti_TalkPanel;

    public TextMeshPro LumineText;
    public TextMeshPro VentiText;

    // Start is called before the first frame update
    void Start()
    {
        Lumine_TalkPanel.SetActive(false);
        Venti_TalkPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //TextPrint();
        }
    }

    public void Action(int _ID, string _content)
    {
        //여행자
        if (_ID == 1000)
        {
            Lumine_TalkPanel.SetActive(true);
            LumineText.text = _content;
        }

        //벤티
        else if (_ID == 1001)
        {
            Lumine_TalkPanel.SetActive(true);
        }
    }
}
