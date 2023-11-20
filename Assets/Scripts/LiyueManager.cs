using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiyueManager : MonoBehaviour
{
    public TextAsset data;
    private LiyueAllData datas;

    public PlayerMove playerMove;
    public VentiMove ventiMove;

    public GameObject LiyueUI;

    public GameObject Lumine_TalkPanel;
    public GameObject Venti_TalkPanel;
    public GameObject Paimon_TalkPanel;
    public GameObject Paimon_TalkPanel_flip;

    public TextMeshPro LumineText;
    public TextMeshPro VentiText;
    public TextMeshPro PaimonText;

    public bool paimonflip = true;
    private void Awake()
    {
        datas = JsonUtility.FromJson<LiyueAllData>(data.text);
        Lumine_TalkPanel.SetActive(false);
        Venti_TalkPanel.SetActive(false);
        Paimon_TalkPanel.SetActive(false);
        Paimon_TalkPanel_flip.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerMove.NotSad();
        playerMove.MoveStart();
        LiyueUI.GetComponent<UIControl>().UIStage();
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
            Paimon_TalkPanel.SetActive(false);
            Venti_TalkPanel.SetActive(false);
            Lumine_TalkPanel.SetActive(true);
            LumineText.text = _content;
        }

        //페이몬
        else if (_ID == 1002)
        {
            Lumine_TalkPanel.SetActive(false);
            Venti_TalkPanel.SetActive(false);
            Paimon_TalkPanel.SetActive(true);
            PaimonText.text = _content;
        }

        //응광
        else if (_ID == 3001)
        {
            Paimon_TalkPanel.SetActive(false);
            Lumine_TalkPanel.SetActive(false);
            Venti_TalkPanel.SetActive(true);
            VentiText.text = _content;
        }

        print(_ID);
        print(_content);
    }

    private int i = 0;

    public void TextPrint()
    {
        Action(datas.LiyueText[i].ID, datas.LiyueText[i].content);

        if (i < datas.LiyueText.Length - 1)
            i++;
    }
}

[System.Serializable]
public class LiyueAllData
{
    public TextData[] LiyueText;
}

[System.Serializable]
public class LiyueTextData
{
    public int ID;
    public string name;
    public string content;
}
