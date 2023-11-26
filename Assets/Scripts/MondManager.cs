using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MondManager : MonoBehaviour
{
    public TextAsset data;
    private AllData datas;

    public GameObject liyueManager;

    public PlayerMove playerMove;
    public VentiMove ventiMove;
    public TypeEffect typeEffect;
    public CutUI cutUI;

    public GameObject MondUI;

    public GameObject Lumine_TalkPanel;
    public GameObject Venti_TalkPanel;
    public GameObject Paimon_TalkPanel_flip;
    public GameObject Paimon_TalkPanel;

    public TextMeshPro LumineText;
    public TextMeshPro VentiText;
    public TextMeshPro PaimonText_flip;
    public TextMeshPro PaimonText;

    public bool paimonflip = false;
    private void Awake()
    {
        datas = JsonUtility.FromJson<AllData>(data.text);
        Lumine_TalkPanel.SetActive(false);
        Venti_TalkPanel.SetActive(false);
        Paimon_TalkPanel_flip.SetActive(false);
        Paimon_TalkPanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        cutUI.ok = true;
        playerMove.PlayerSad();
        playerMove.PaimonSad();
        MondUI.GetComponent<UIControl>().UIStage();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.textmode == true && ventiMove.textmode == true && cutUI.ok == true)
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
            Paimon_TalkPanel_flip.SetActive(false);
            Venti_TalkPanel.SetActive(false);
            Lumine_TalkPanel.SetActive(true);
            typeEffect.SetMsg(LumineText, _content);
            if(_action == "NotSad")
            {
                playerMove.NotSad();
            }
            playerMove.PlayerTalk();
        }

        //페이몬
        else if (_ID == 1002)
        {
            if(_action == "flip")
            {
                paimonflip = false;
                playerMove.PaimonFlip(paimonflip);
            }

            if (_action == "NotSad")
            {
                playerMove.NotSad();
            }

            //여행자 안보고 있을 때
            if (paimonflip == false)
            {
                Lumine_TalkPanel.SetActive(false);
                Venti_TalkPanel.SetActive(false);
                Paimon_TalkPanel_flip.SetActive(false);
                Paimon_TalkPanel.SetActive(true);
                typeEffect.SetMsg(PaimonText, _content);
            }

            //여행자 보고 있을 때
            else
            {
                Lumine_TalkPanel.SetActive(false);
                Venti_TalkPanel.SetActive(false);
                Paimon_TalkPanel.SetActive(false);
                Paimon_TalkPanel_flip.SetActive(true);
                typeEffect.SetMsg(PaimonText_flip, _content);
            }
            playerMove.PaimonTalk();
        }

        //벤티
        else if (_ID == 2001)
        {
            if (_action == "isWalking")
            {
                ventiMove.VentiAppear();
                if(ventiMove.textmode == true)
                {
                    Venti_TalkPanel.SetActive(true);
                    typeEffect.SetMsg(VentiText, _content);
                    return;
                }
            }
            Paimon_TalkPanel.SetActive(false);
            Paimon_TalkPanel_flip.SetActive(false);
            Lumine_TalkPanel.SetActive(false);
            Venti_TalkPanel.SetActive(true);
            typeEffect.SetMsg(VentiText, _content);

            ventiMove.VentiTalk();
        }

        print(_ID);
        print(_content);
    }

    private int i = -1;

    public void TextPrint()
    {
        if (i <= datas.MondText.Length - 1)
        {
            if (typeEffect.isAnim == false)
            {
                i++;
            }        
        }

        if (i == datas.MondText.Length)
        {
            cutUI.ok = false;
            ActionSet();
            Paimon_TalkPanel_flip.SetActive(false);
            cutUI.nextScript = liyueManager;
            cutUI.cutIndex = 0;
            cutUI.CutAppear();
            return;
        }
        Action(datas.MondText[i].ID, datas.MondText[i].content, datas.MondText[i].action);

    }

    void ActionSet()
    {
        playerMove.PlayerNotTalk();
        playerMove.PaimonNotTalk();
        ventiMove.VentiNotTalk();
    }
}

[System.Serializable]
public class AllData 
{
    public TextData[] MondText;
}

[System.Serializable]
public class TextData
{
    public int ID;
    public string name;
    public string action;
    public string content;
}