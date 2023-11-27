using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InazumaManager : MonoBehaviour
{
    public TextAsset data;
    private InazumaAllText datas;

    public GameObject sumeruManager;
    public GameObject liyueManager2;

    public PlayerMove playerMove;
    public NPCMove nPCMove;
    public TypeEffect typeEffect;
    public CutUI cutUI;

    public GameObject InazumaUI;

    public GameObject Lumine_TalkPanel;
    public GameObject Raiden_TalkPanel;
    public GameObject Paimon_TalkPanel;
    public GameObject Paimon_TalkPanel_flip;

    public TextMeshPro LumineText;
    public TextMeshPro RaidenText;
    public TextMeshPro PaimonText;
    public TextMeshPro PaimonText_flip;

    public GameObject stepPosition;
    public float walkspeed;

    public bool paimonflip = false;
    string beforetext;

    private void Awake()
    {
        datas = JsonUtility.FromJson<InazumaAllText>(data.text);
        TalkPanelFalse();
    }

    void Start()
    {
        liyueManager2.SetActive(false);
        playerMove.MoveStart();
        playerMove.PaimonFlip(paimonflip);
    }

    void Update()
    {
        if (playerMove.isMoving == false)
        {
            InazumaUI.GetComponent<UIControl>().UIStage();
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

        if(_action == "Move")
        {
            StartCoroutine(playerMove.PlayerStep(stepPosition, walkspeed, false));
        }

        //여행자
        if (_ID == 1001)
        {
            if (_action == "isReceving")
            {
                playerMove.PlayerReceive();
                nPCMove.RaidenAfterPrize();
            }

            if (_action == "ReceveEnd")
            {
                playerMove.PlayerNotReceive();
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

        //라이덴
        else if (_ID == 4001)
        {
            if (_action == "isGiving")
            {
                nPCMove.RaidenPrize();
            }
            Raiden_TalkPanel.SetActive(true);
            typeEffect.SetMsg(RaidenText, _content);

            nPCMove.RaidenTalk();
        }
        beforetext = _content;
        print(_ID);
        print(_content);
    }

    private int i = -1;

    public void TextPrint()
    {
        if (i <= datas.InazumaText.Length - 1)
        {
            if (typeEffect.isAnim == false)
            {
                i++;
            }
        }

        if (i == datas.InazumaText.Length)
        {
            cutUI.ok = false;
            ActionSet();
            TalkPanelFalse();
            cutUI.nextScript = sumeruManager;
            cutUI.cutIndex = 2;
            cutUI.CutAppear();
            return;
        }
        Action(datas.InazumaText[i].ID, datas.InazumaText[i].content, datas.InazumaText[i].action);
    }

    public void TalkPanelFalse()
    {
        Paimon_TalkPanel.SetActive(false);
        Paimon_TalkPanel_flip.SetActive(false);
        Raiden_TalkPanel.SetActive(false);
        Lumine_TalkPanel.SetActive(false);
    }

    void ActionSet()
    {
        playerMove.PlayerNotTalk();
        playerMove.PaimonNotTalk();
        nPCMove.RaidenNotTalk();
    }
}

[System.Serializable]
public class InazumaAllText
{
    public TextData[] InazumaText;
}
