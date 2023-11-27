using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SumeruManager3 : MonoBehaviour
{
    public TextAsset data;
    private Sumeru3AllData datas;

    public GameObject sumeruManager2;
    public GameObject fontaineManager;

    public PlayerMove playerMove;
    public NPCMove nPCMove;
    public TypeEffect typeEffect;

    public GameObject SumeruUI;
    public GameObject UImove;
    public CutUI cutUI;

    public GameObject Lumine_TalkPanel;
    public GameObject Nahida_TalkPanel;
    public GameObject Paimon_TalkPanel;
    public GameObject Paimon_TalkPanel_flip;

    public TextMeshPro LumineText;
    public TextMeshPro NahidaText;
    public TextMeshPro PaimonText;
    public TextMeshPro PaimonText_flip;

    public bool paimonflip = false;
    string beforetext;

    private void Awake()
    {
        datas = JsonUtility.FromJson<Sumeru3AllData>(data.text);
        TalkPanelFalse();
    }
    // Start is called before the first frame update
    void Start()
    {
        sumeruManager2.SetActive(false);
        playerMove.MoveStart();
        playerMove.PaimonFlip(paimonflip);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.isMoving == true)
        {
            while (SumeruUI.transform.position != UImove.transform.position)
            {
                SumeruUI.transform.position = Vector3.MoveTowards(SumeruUI.transform.position, UImove.transform.position, Time.deltaTime * playerMove.speed);
            }
        }

        if (playerMove.textmode == true && cutUI.ok == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TextPrint();
            }
        }
    }

    public void Action(int _ID, string _content, string _action)
    {
        ActionSet();
        TalkPanelFalse();

        //여행자
        if (_ID == 1001)
        {
            if (_action == "Sad")
            {
                playerMove.PlayerSad();
            }

            if (_action == "NotSad")
            {
                playerMove.PlayerNotSad();
            }
            Lumine_TalkPanel.SetActive(true);
            typeEffect.SetMsg(LumineText, _content);

            playerMove.PlayerTalk();
        }

        //페이몬
        else if (_ID == 1002)
        {
            if (_action == "flip" && beforetext != _content)
            {
                if (paimonflip == true)
                {
                    paimonflip = false;
                }
                else
                {
                    paimonflip = true;
                }
                playerMove.PaimonFlip(paimonflip);
            }         

            //여행자 안보고 있을 때
            if (paimonflip == false)
            {
                Paimon_TalkPanel.SetActive(true);
                typeEffect.SetMsg(PaimonText, _content);
            }

            //여행자 보고 있을 때
            else
            {
                Paimon_TalkPanel_flip.SetActive(true);
                typeEffect.SetMsg(PaimonText_flip, _content);
            }
            playerMove.PaimonTalk();
        }

        //나히다
        else if (_ID == 5002)
        {
            Nahida_TalkPanel.SetActive(true);
            typeEffect.SetMsg(NahidaText, _content);

            nPCMove.NahidaTalk();
        }
        beforetext = _content;
        print(_ID);
        print(_content);
    }

    private int i = -1;

    public void TextPrint()
    {
        if (i <= datas.SumeruText3.Length - 1)
        {
            if (typeEffect.isAnim == false)
            {
                i++;
            }
        }

        if (i == datas.SumeruText3.Length)
        {
            if (i == datas.SumeruText3.Length)
            {
                cutUI.ok = false;
                ActionSet();
                TalkPanelFalse();
                cutUI.nextScript = fontaineManager;
                cutUI.cutIndex = 4;
                cutUI.CutAppear();
                return;
            }
        }
        Action(datas.SumeruText3[i].ID, datas.SumeruText3[i].content, datas.SumeruText3[i].action);
    }

    public void TalkPanelFalse()
    {
        Paimon_TalkPanel.SetActive(false);
        Nahida_TalkPanel.SetActive(false);
        Lumine_TalkPanel.SetActive(false);
        Paimon_TalkPanel_flip.SetActive(false);
    }

    void ActionSet()
    {
        playerMove.PlayerNotTalk();
        playerMove.PaimonNotTalk();
        nPCMove.NahidaNotTalk();
    }
}

[System.Serializable]
public class Sumeru3AllData
{
    public TextData[] SumeruText3;
}
