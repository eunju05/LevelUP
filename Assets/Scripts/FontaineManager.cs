using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FontaineManager : MonoBehaviour
{
    public TextAsset data;
    private FontaineAllData datas;

    public GameObject sumeruManager3;
    public GameObject finalManager;

    public PlayerMove playerMove;
    public NPCMove nPCMove;
    public TypeEffect typeEffect;

    public GameObject FontaineUI;
    public CutUI cutUI;
    
    public GameObject Lumine_TalkPanel;
    public GameObject Furina_TalkPanel;
    public GameObject Neuvillette_TalkPanel;
    public GameObject Paimon_TalkPanel;
    public GameObject Paimon_TalkPanel_flip;

    public TextMeshPro LumineText;
    public TextMeshPro FurinaText;
    public TextMeshPro NeuvilletteText;
    public TextMeshPro PaimonText;
    public TextMeshPro PaimonText_flip;

    public GameObject stepPosition;
    public GameObject stepPosition2;
    public GameObject stepPosition3;
    public float walkspeed;

    public bool paimonflip = false;
    string beforetext;

    private void Awake()
    {
        datas = JsonUtility.FromJson<FontaineAllData>(data.text);
        TalkPanelFalse();
    }
    // Start is called before the first frame update
    void Start()
    {
        sumeruManager3.SetActive(false);
        playerMove.MoveStart();
        playerMove.PaimonFlip(paimonflip);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.isMoving == false)
        {
            FontaineUI.GetComponent<UIControl>().UIStage();
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
            if (_action == "Work")
            {
                StartCoroutine(playerMove.Working(stepPosition, stepPosition2, stepPosition3, walkspeed, false));
            }

            else
            {
                Lumine_TalkPanel.SetActive(true);
                typeEffect.SetMsg(LumineText, _content);

                playerMove.PlayerTalk();
            }
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

        //느비예트
        else if (_ID == 6001)
        {
            Neuvillette_TalkPanel.SetActive(true);
            typeEffect.SetMsg(NeuvilletteText, _content);

            nPCMove.NeuvilletteTalk();
        }

        //푸리나
        else if (_ID == 6002)
        {           
            Furina_TalkPanel.SetActive(true);
            typeEffect.SetMsg(FurinaText, _content);

            nPCMove.FurinaTalk();
        }
        beforetext = _content;
        print(_ID);
        print(_content);
    }

    private int i = -1;

    public void TextPrint()
    {
        if (i <= datas.FontaineText.Length - 1)
        {
            if (typeEffect.isAnim == false)
            {
                i++;
            }
        }

        if (i == datas.FontaineText.Length)
        {
            if (i == datas.FontaineText.Length)
            {
                cutUI.ok = false;
                ActionSet();
                TalkPanelFalse();
                cutUI.nextScript = finalManager;
                cutUI.cutIndex = 5;
                cutUI.CutAppear();
                return;
            }
        }
        Action(datas.FontaineText[i].ID, datas.FontaineText[i].content, datas.FontaineText[i].action);
    }

    public void TalkPanelFalse()
    {
        Paimon_TalkPanel.SetActive(false);
        Furina_TalkPanel.SetActive(false);
        Neuvillette_TalkPanel.SetActive(false);
        Lumine_TalkPanel.SetActive(false);
        Paimon_TalkPanel_flip.SetActive(false);
    }

    void ActionSet()
    {
        playerMove.PlayerNotTalk();
        playerMove.PaimonNotTalk();
        nPCMove.FurinaNotTalk();
        nPCMove.NeuvilletteNotTalk();
    }
}

[System.Serializable]
public class FontaineAllData
{
    public TextData[] FontaineText;
}
