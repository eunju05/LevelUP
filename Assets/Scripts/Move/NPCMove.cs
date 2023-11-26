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

    /*----- 리월 -----*/
    //응광
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

    //종려
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

    /*----- 이나즈마 -----*/
    //라이덴
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

    /*----- 수메르 -----*/
    //나히다
    public void NahidaTalk()
    {
        nahida_anim.SetBool("isTalking", true);
    }

    public void NahidaNotTalk()
    {
        nahida_anim.SetBool("isTalking", false);
    }

    //알하이탐
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


    /*----- 폰타인 -----*/
    //푸리나
    public void FurinaTalk()
    {
        furina_anim.SetBool("isTalking", true);
    }

    public void FurinaNotTalk()
    {
        furina_anim.SetBool("isTalking", false);
    }

    //느비예트
    public void NeuvilletteTalk()
    {
        neuvillette_anim.SetBool("isTalking", true);
    }

    public void NeuvilletteNotTalk()
    {
        neuvillette_anim.SetBool("isTalking", false);
    }
}
