using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextAsset data;
    private AllData datas;

    public PlayerMove playerMove;
    public VentiMove ventiMove;

    public GameObject MondUI;

    public GameObject Lumine_TalkPanel;
    public GameObject Venti_TalkPanel;

    public TextMeshPro LumineText;
    public TextMeshPro VentiText;

    private void Awake()
    {
        datas = JsonUtility.FromJson<AllData>(data.text);
        Lumine_TalkPanel.SetActive(false);
        Venti_TalkPanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerMove.PlayerSad();
        playerMove.PaimonSad();
        MondUI.GetComponent<UIControl>().UIStage();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.textmode == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TextPrint();
            }
        }
    }

    public void Action(int _ID, string _content)
    {
        //여행자
        if (_ID == 1001)
        {
            Lumine_TalkPanel.SetActive(true);
            LumineText.text = _content;
            
        }

        //벤티
        else if (_ID == 1002)
        {
            Venti_TalkPanel.SetActive(true);
            VentiText.text = _content;
        }

        print(_ID);
        print(_content);
    }

    private int i = 0;

    public void TextPrint()
    {      
        Action(datas.TextScript[i].ID, datas.TextScript[i].content);

        if (i < datas.TextScript.Length - 1)
            i++;
    }
}

[System.Serializable]
public class AllData 
{
    public TextData[] TextScript;
}

[System.Serializable]
public class TextData
{
    public int ID;
    public string name;
    public string content;
}