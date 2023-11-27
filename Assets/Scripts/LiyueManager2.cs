using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiyueManager2 : MonoBehaviour
{
    public TextAsset data;
    private Liyue2AllText datas;

    public GameObject inazumaManager;
    public GameObject liyueManager;

    public PlayerMove playerMove;
    public NPCMove nPCMove;
    public TypeEffect typeEffect;
    public CutUI cutUI;

    public GameObject LiyueUI;
    public GameObject UImove;

    public GameObject Lumine_TalkPanel;
    public GameObject Zhongli_TalkPanel;
    public GameObject Paimon_TalkPanel;
    public GameObject Paimon_TalkPanel_flip;

    public TextMeshPro LumineText;
    public TextMeshPro ZhongliText;
    public TextMeshPro PaimonText;
    public TextMeshPro PaimonText_flip;

    public float speed = 2;

    public bool paimonflip = false;
    string beforetext;

    private void Awake()
    {
        datas = JsonUtility.FromJson<Liyue2AllText>(data.text);
        TalkPanelFalse();
    }

    void Start()
    {
        liyueManager.SetActive(false);
        playerMove.MoveStart();
    }

    void Update()
    {
        if (playerMove.isMoving == true)
        {
            LiyueUI.transform.position = Vector3.MoveTowards(LiyueUI.transform.position, UImove.transform.position, Time.deltaTime * speed);
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

        //여행자
        if (_ID == 1001)
        {
            TalkPanelFalse();
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
                TalkPanelFalse();
                Paimon_TalkPanel.SetActive(true);
                typeEffect.SetMsg(PaimonText, _content);
            }

            //여행자 보고 있을 때
            else
            {
                TalkPanelFalse();
                Paimon_TalkPanel_flip.SetActive(true);
                typeEffect.SetMsg(PaimonText_flip, _content);
            }
            playerMove.PaimonTalk();
        }

        //종려
        else if (_ID == 3002)
        {
            if (_action == "isTeaching")
            {
                nPCMove.ZhongliTeach();
                Debug.Log("듣중");
                playerMove.PlayerStudy();
            }

            if (_action == "TeachEnd")
            {
                nPCMove.ZhongliNotTeach();
                playerMove.PlayerNotStudy();
            }
            Paimon_TalkPanel.SetActive(false);
            Paimon_TalkPanel_flip.SetActive(false);
            Lumine_TalkPanel.SetActive(false);
            Zhongli_TalkPanel.SetActive(true);
            typeEffect.SetMsg(ZhongliText, _content);

            nPCMove.ZhongliTalk();
        }
        beforetext = _content;
        print(_ID);
        print(_content);
    }

    private int i = -1;

    public void TextPrint()
    {
        if (i <= datas.LiyueText2.Length - 1)
        {
            if (typeEffect.isAnim == false)
            {
                i++;
            }
        }

        if (i == datas.LiyueText2.Length)
        {
            cutUI.ok = false;
            ActionSet();
            TalkPanelFalse();
            cutUI.nextScript = inazumaManager;
            cutUI.cutIndex = 1;
            cutUI.CutAppear();
            return;
        }
        Action(datas.LiyueText2[i].ID, datas.LiyueText2[i].content, datas.LiyueText2[i].action);
    }

    public void TalkPanelFalse()
    {
        Paimon_TalkPanel.SetActive(false);
        Paimon_TalkPanel_flip.SetActive(false);
        Zhongli_TalkPanel.SetActive(false);
        Lumine_TalkPanel.SetActive(false);
    }

    void ActionSet()
    {
        playerMove.PlayerNotTalk();
        playerMove.PaimonNotTalk();
        nPCMove.ZhongliNotTalk();
    }
}

[System.Serializable]
public class Liyue2AllText
{
    public TextData[] LiyueText2;
}
