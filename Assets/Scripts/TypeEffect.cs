using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSecond;
    public bool isAnim;

    string targetMsg;
    int index;
    float interval;

    public void SetMsg(TextMeshPro _NPCText, string msg)
    {
        //�ִϸ��̼� ���� ���� �� �� �� Ŭ���ϸ�
        if (isAnim)
        {
            //�ؽ�Ʈ �ٷ� ä�� ��
            _NPCText.text = msg;
            //�ؽ�Ʈ �ۼ� �ڷ�ƾ ���߰� �ٷ� ����
            StopCoroutine(Effecting(_NPCText));
            targetMsg = "";
            EffectEnd(_NPCText);
        }
        else
        {
            targetMsg = msg;
            EffectStart(_NPCText);
        }
    }

    void EffectStart(TextMeshPro _NPCText)
    {
        _NPCText.text = "";
        index = 0;
        _NPCText.transform.GetChild(0).gameObject.SetActive(false);

        isAnim = true;
        interval = 1.0f / CharPerSecond;
        StartCoroutine(Effecting(_NPCText));
    }    

    IEnumerator Effecting(TextMeshPro _NPCText)
    {
        if(_NPCText.text == targetMsg)
        {
            EffectEnd(_NPCText);
            yield break;
        }
        _NPCText.text += targetMsg[index];
        index++;
        yield return new WaitForSeconds(interval);
        StartCoroutine(Effecting(_NPCText));
    }

    void EffectEnd(TextMeshPro _NPCText)
    {        
        _NPCText.transform.GetChild(0).gameObject.SetActive(true);
        isAnim = false;
    }
}
