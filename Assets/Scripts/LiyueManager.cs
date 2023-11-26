using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiyueManager : MonoBehaviour
{
    public TextAsset data;
    private LiyueAllData datas;

    public GameObject MondManager;
    public GameObject LiyueManager2;

    public PlayerMove playerMove;
    public NPCMove nPCMove;
    public TypeEffect typeEffect;

    public GameObject LiyueUI;

    public GameObject Lumine_TalkPanel;
    public GameObject Ningguang_TalkPanel;
    public GameObject Paimon_TalkPanel;

    public TextMeshPro LumineText;
    public TextMeshPro NingguangText;
    public TextMeshPro PaimonText;

    private void Awake()
    {
        datas = JsonUtility.FromJson<LiyueAllData>(data.text);
        Lumine_TalkPanel.SetActive(false);
        Ningguang_TalkPanel.SetActive(false);
        Paimon_TalkPanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        MondManager.SetActive(false);
        playerMove.NotSad();
        playerMove.MoveStart();        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.isMoving == false)
        {
            LiyueUI.GetComponent<UIControl>().UIStage();
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

        //여행자
        if (_ID == 1001)
        {
            Paimon_TalkPanel.SetActive(false);
            Ningguang_TalkPanel.SetActive(false);
            Lumine_TalkPanel.SetActive(true);
            typeEffect.SetMsg(LumineText, _content);

            playerMove.PlayerTalk();
        }

        //페이몬
        else if (_ID == 1002)
        {
            Lumine_TalkPanel.SetActive(false);
            Ningguang_TalkPanel.SetActive(false);
            Paimon_TalkPanel.SetActive(true);
            typeEffect.SetMsg(PaimonText, _content);

            playerMove.PaimonTalk();
        }

        //응광
        else if (_ID == 3001)
        {
            if(_action == "isTeaching")
            {
                nPCMove.NingguangTeach();
                playerMove.PlayerStudy();
            }

            if(_action == "TeachEnd")
            {
                nPCMove.NingguangNotTeach();
                playerMove.PlayerNotStudy();
            }
            Paimon_TalkPanel.SetActive(false);
            Lumine_TalkPanel.SetActive(false);
            Ningguang_TalkPanel.SetActive(true);
            typeEffect.SetMsg(NingguangText, _content);

            nPCMove.NingguangTalk();
        }

        print(_ID);
        print(_content);
    }

    private int i = -1;

    public void TextPrint()
    {
        if (i <= datas.LiyueText1.Length - 1)
        {
            if (typeEffect.isAnim == false)
            {
                i++;
            }
        }

        if (i == datas.LiyueText1.Length)
        {
            ActionSet();
            TalkPanelFalse();
            LiyueManager2.SetActive(true);
            return;
        }
        Action(datas.LiyueText1[i].ID, datas.LiyueText1[i].content, datas.LiyueText1[i].action);
    }

    public void TalkPanelFalse()
    {
        Paimon_TalkPanel.SetActive(false);
        Ningguang_TalkPanel.SetActive(false);
        Lumine_TalkPanel.SetActive(false);
    }

    void ActionSet()
    {
        playerMove.PlayerNotTalk();
        playerMove.PaimonNotTalk();
        nPCMove.NingguangNotTalk();
    }
}

[System.Serializable]
public class LiyueAllData
{
    public TextData[] LiyueText1;
}

[System.Serializable]
public class LiyueTextData
{
    public int ID;
    public string name;
    public string action;
    public string content;
}
