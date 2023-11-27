using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SumeruManager : MonoBehaviour
{
    public TextAsset data;
    private SumeruAllData datas;

    public GameObject inazumaManager;
    public GameObject sumeruManager2;

    public PlayerMove playerMove;
    public NPCMove nPCMove;
    public TypeEffect typeEffect;

    public GameObject SumeruUI;
    public CutUI cutUI;

    public GameObject Lumine_TalkPanel;
    public GameObject Alhaitham_TalkPanel;
    public GameObject Paimon_TalkPanel;
    public GameObject Paimon_TalkPanel_flip;

    public TextMeshPro LumineText;
    public TextMeshPro AlhaithamText;
    public TextMeshPro PaimonText;
    public TextMeshPro PaimonText_flip;

    public bool paimonflip = false;
    string beforetext;

    private void Awake()
    {
        datas = JsonUtility.FromJson<SumeruAllData>(data.text);
        TalkPanelFalse();
    }
    // Start is called before the first frame update
    void Start()
    {
        inazumaManager.SetActive(false);
        playerMove.MoveStart();
        playerMove.PaimonFlip(paimonflip);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.isMoving == false)
        {
            SumeruUI.GetComponent<UIControl>().UIStage();
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

            if(_action == "Sad")
            {
                playerMove.PaimonSad();
            }

            if (_action == "flipNotSad")
            {
                playerMove.PaimonNotSad();
                playerMove.PaimonFlip(true);
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

        //알하이탐
        else if (_ID == 5001)
        {
            if (_action == "isTeaching")
            {
                paimonflip = false;
                playerMove.PaimonFlip(paimonflip);

                nPCMove.AlhaithamTeach();
                playerMove.PlayerStudy();
            }

            if (_action == "TeachEnd")
            {
                nPCMove.AlhaithamNotTeach();
                playerMove.PlayerNotStudy();
            }
            Alhaitham_TalkPanel.SetActive(true);
            typeEffect.SetMsg(AlhaithamText, _content);

            nPCMove.AlhaithamTalk();
        }
        beforetext = _content;
        print(_ID);
        print(_content);
    }

    private int i = -1;

    public void TextPrint()
    {
        if (i <= datas.SumeruText1.Length - 1)
        {
            if (typeEffect.isAnim == false)
            {
                i++;
            }
        }

        if (i == datas.SumeruText1.Length)
        {
            if (i == datas.SumeruText1.Length)
            {
                cutUI.ok = false;
                ActionSet();
                TalkPanelFalse();
                cutUI.nextScript = sumeruManager2;
                cutUI.cutIndex = 3;
                cutUI.CutAppear();
                return;
            }
        }
        Action(datas.SumeruText1[i].ID, datas.SumeruText1[i].content, datas.SumeruText1[i].action);
    }

    public void TalkPanelFalse()
    {
        Paimon_TalkPanel.SetActive(false);
        Alhaitham_TalkPanel.SetActive(false);
        Lumine_TalkPanel.SetActive(false);
        Paimon_TalkPanel_flip.SetActive(false);
    }

    void ActionSet()
    {
        playerMove.PlayerNotTalk();
        playerMove.PaimonNotTalk();
        nPCMove.AlhaithamNotTalk();
    }
}

[System.Serializable]
public class SumeruAllData
{
    public TextData[] SumeruText1;
}
