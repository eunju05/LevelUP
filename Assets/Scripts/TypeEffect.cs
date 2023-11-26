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
        //애니메이션 실행 도중 한 번 더 클릭하면
        if (isAnim)
        {
            //텍스트 바로 채운 후
            _NPCText.text = msg;
            //텍스트 작성 코루틴 멈추고 바로 종료
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
