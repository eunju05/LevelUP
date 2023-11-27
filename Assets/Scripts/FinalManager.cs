using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalManager : MonoBehaviour
{
    public TextAsset data;
    private FinalAllData datas;

    public GameObject fontaineManager;

    public PlayerMove playerMove;
    public VentiMove ventiMove;
    public TypeEffect typeEffect;

    public GameObject MondUI;

    public GameObject Lumine_TalkPanel;
    public GameObject Venti_TalkPanel;
    public GameObject Paimon_TalkPanel;
    public GameObject Paimon_TalkPanel_flip;

    public TextMeshPro LumineText;
    public TextMeshPro VentiText;
    public TextMeshPro PaimonText;
    public TextMeshPro PaimonText_flip;

    public bool paimonflip = false;
    string beforetext;

    private void Awake()
    {
        datas = JsonUtility.FromJson<FinalAllData>(data.text);
        TalkPanelFalse();
    }
    // Start is called before the first frame update
    void Start()
    {
        fontaineManager.SetActive(false);
        playerMove.MoveStart();
        playerMove.PaimonFlip(paimonflip);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.isMoving == false)
        {
            MondUI.GetComponent<UIControl>().UIStage();
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

        //벤티
        else if (_ID == 2001)
        {
            Venti_TalkPanel.SetActive(true);
            typeEffect.SetMsg(VentiText, _content);

            ventiMove.VentiTalk();
        }
        beforetext = _content;
        print(_ID);
        print(_content);
    }

    private int i = -1;

    public void TextPrint()
    {
        if (i <= datas.FinalText.Length - 1)
        {
            if (typeEffect.isAnim == false)
            {
                i++;
            }
        }

        if (i == datas.FinalText.Length)
        {
            if (i == datas.FinalText.Length)
            {                
                ActionSet();
                TalkPanelFalse();
                return;
            }
        }
        Action(datas.FinalText[i].ID, datas.FinalText[i].content, datas.FinalText[i].action);
    }

    public void TalkPanelFalse()
    {
        Paimon_TalkPanel.SetActive(false);
        Venti_TalkPanel.SetActive(false);
        Lumine_TalkPanel.SetActive(false);
        Paimon_TalkPanel_flip.SetActive(false);
    }

    void ActionSet()
    {
        playerMove.PlayerNotTalk();
        playerMove.PaimonNotTalk();
        ventiMove.VentiNotTalk();
    }
}

[System.Serializable]
public class FinalAllData
{
    public TextData[] FinalText;
}