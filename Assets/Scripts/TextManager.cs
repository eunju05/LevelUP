using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextAsset data;
    private AllData datas;

    public GameObject liyueManager;

    public PlayerMove playerMove;
    public VentiMove ventiMove;

    public GameObject MondUI;

    public GameObject Lumine_TalkPanel;
    public GameObject Venti_TalkPanel;
    public GameObject Paimon_TalkPanel_flip;
    public GameObject Paimon_TalkPanel;

    public TextMeshPro LumineText;
    public TextMeshPro VentiText;
    public TextMeshPro PaimonText_flip;
    public TextMeshPro PaimonText;

    public bool paimonflip = true;
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
        playerMove.PlayerSad();
        playerMove.PaimonSad(paimonflip);
        MondUI.GetComponent<UIControl>().UIStage();
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
        //������
        if (_ID == 1001)
        {
            Paimon_TalkPanel.SetActive(false);
            Paimon_TalkPanel_flip.SetActive(false);
            Venti_TalkPanel.SetActive(false);
            Lumine_TalkPanel.SetActive(true);
            LumineText.text = _content;            
        }

        //���̸�
        else if (_ID == 1002)
        {
            if (paimonflip == false)
            {
                Lumine_TalkPanel.SetActive(false);
                Venti_TalkPanel.SetActive(false);
                Paimon_TalkPanel_flip.SetActive(false);
                Paimon_TalkPanel.SetActive(true);
                PaimonText.text = _content;
            }

            else
            {
                Lumine_TalkPanel.SetActive(false);
                Venti_TalkPanel.SetActive(false);
                Paimon_TalkPanel.SetActive(false);
                Paimon_TalkPanel_flip.SetActive(true);
                PaimonText_flip.text = _content;
            }
        }

        //��Ƽ
        else if (_ID == 2001)
        {
            Paimon_TalkPanel.SetActive(false);
            Paimon_TalkPanel_flip.SetActive(false);
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

        if (i <= datas.TextScript.Length - 1)
        {
            Action(datas.TextScript[i].ID, datas.TextScript[i].content);
            i++;
        }

        if(i == datas.TextScript.Length)
        {
            liyueManager.SetActive(true);
        }
    }
}

[System.Serializable]
public class AllData 
{
    public TextData[] TextScript;
}

[System.Serializable]
public class TextData
{
    public int ID;
    public string name;
    public string content;
}