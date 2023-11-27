using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SumeruManager2 : MonoBehaviour
{
    public TextAsset data;
    private Sumeru2AllData datas;

    public GameObject sumeruManager;
    public GameObject sumeruManager3;

    public PlayerMove playerMove;
    public NPCMove nPCMove;
    public TypeEffect typeEffect;

    public GameObject SumeruUI;
    public GameObject UImove;

    public GameObject Lumine_TalkPanel;
    public GameObject Paimon_TalkPanel;
    public GameObject Paimon_TalkPanel_flip;

    public TextMeshPro LumineText;
    public TextMeshPro PaimonText;
    public TextMeshPro PaimonText_flip;

    public bool paimonflip = false;
    string beforetext;

    private void Awake()
    {
        datas = JsonUtility.FromJson<Sumeru2AllData>(data.text);
        TalkPanelFalse();
    }
    // Start is called before the first frame update
    void Start()
    {
        sumeruManager.SetActive(false);
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

        if (playerMove.textmode == true)
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

        beforetext = _content;
        print(_ID);
        print(_content);
    }

    private int i = -1;

    public void TextPrint()
    {
        if (i <= datas.SumeruText2.Length - 1)
        {
            if (typeEffect.isAnim == false)
            {
                i++;
            }
        }

        if (i == datas.SumeruText2.Length)
        {
            if (i == datas.SumeruText2.Length)
            {
                ActionSet();
                TalkPanelFalse();
                sumeruManager3.SetActive(true);
                return;
            }
        }
        Action(datas.SumeruText2[i].ID, datas.SumeruText2[i].content, datas.SumeruText2[i].action);
    }

    public void TalkPanelFalse()
    {
        Paimon_TalkPanel.SetActive(false);
        Lumine_TalkPanel.SetActive(false);
        Paimon_TalkPanel_flip.SetActive(false);
    }

    void ActionSet()
    {
        playerMove.PlayerNotTalk();
        playerMove.PaimonNotTalk();
    }
}

[System.Serializable]
public class Sumeru2AllData
{
    public TextData[] SumeruText2;
}
