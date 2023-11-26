using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public GameObject _ningguang;
    public GameObject _zhongli;
    public GameObject _raiden;
    public GameObject _nahida;
    public GameObject _alhaitham;
    public GameObject _furina;
    public GameObject _neuvillette;

    Animator ningguang_anim;
    Animator zhongli_anim;
    Animator raiden_anim;
    Animator nahida_anim;
    Animator alhaitham_anim;
    Animator furina_anim;
    Animator neuvillette_anim;


    // Start is called before the first frame update
    private void Awake()
    {
        ningguang_anim = _ningguang.GetComponent<Animator>();
        zhongli_anim = _zhongli.GetComponent<Animator>();
        raiden_anim = _raiden.GetComponent<Animator>();
        nahida_anim = _nahida.GetComponent<Animator>();
        alhaitham_anim = _alhaitham.GetComponent<Animator>();
        furina_anim=_furina.GetComponent<Animator>();
        neuvillette_anim = _neuvillette.GetComponent<Animator>();
    }

    /*----- ���� -----*/
    //����
    public void NingguangTalk()
    {
        ningguang_anim.SetBool("isTalking", true);
    }

    public void NingguangNotTalk()
    {
        ningguang_anim.SetBool("isTalking", false);
    }

    public void NingguangTeach()
    {
        ningguang_anim.SetBool("isTeaching", true);
    }

    public void NingguangNotTeach()
    {
        ningguang_anim.SetBool("isTeaching", false);
    }

    //����
    public void ZhongliTalk()
    {
        zhongli_anim.SetBool("isTalking", true);
    }

    public void ZhongliNotTalk()
    {
        zhongli_anim.SetBool("isTalking", false);
    }

    public void ZhongliTeach()
    {
        zhongli_anim.SetBool("isTeaching", true);
    }

    public void ZhongliNotTeach()
    {
        zhongli_anim.SetBool("isTeaching", false);
    }

    /*----- �̳�� -----*/
    //���̵�
    public void RaidenTalk()
    {
        raiden_anim.SetBool("isTalking", true);
    }

    public void RaidenNotTalk()
    {
        raiden_anim.SetBool("isTalking", false);
    }

    public void RaidenPrize()
    {
        raiden_anim.SetBool("isGiving", true);
    }

    public void RaidenAfterPrize()
    {
        raiden_anim.SetBool("isGiving", false);
    }

    /*----- ���޸� -----*/
    //������
    public void NahidaTalk()
    {
        nahida_anim.SetBool("isTalking", true);
    }

    public void NahidaNotTalk()
    {
        nahida_anim.SetBool("isTalking", false);
    }

    //������Ž
    public void AlhaithamTalk()
    {
        alhaitham_anim.SetBool("isTalking", true);
    }

    public void AlhaithamNotTalk()
    {
        alhaitham_anim.SetBool("isTalking", false);
    }

    public void AlhaithamTeach()
    {
        alhaitham_anim.SetBool("isTeaching", true);
    }

    public void AlhaithamNotTeach()
    {
        alhaitham_anim.SetBool("isTeaching", false);
    }


    /*----- ��Ÿ�� -----*/
    //Ǫ����
    public void FurinaTalk()
    {
        furina_anim.SetBool("isTalking", true);
    }

    public void FurinaNotTalk()
    {
        furina_anim.SetBool("isTalking", false);
    }

    //����Ʈ
    public void NeuvilletteTalk()
    {
        neuvillette_anim.SetBool("isTalking", true);
    }

    public void NeuvilletteNotTalk()
    {
        neuvillette_anim.SetBool("isTalking", false);
    }
}
