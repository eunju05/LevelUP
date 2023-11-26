using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public GameObject _player;
    public GameObject _paimon;
    public GameObject[] _playertargetPosition;

    public GameObject _camera;
    public GameObject[] _cameratargetPosition;

    public float speed = 2f;
    public bool isMoving = false;

    public bool textmode = true;

    Animator player_anim;
    Animator pai_anim;
    SpriteRenderer pai_sprite;
    private void Awake()
    {
        player_anim = _player.GetComponent<Animator>();
        pai_anim = _paimon.GetComponent<Animator>();
        pai_sprite = _paimon.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
            
    }

    int i = 0;
    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _cameratargetPosition[i].transform.position, Time.deltaTime * speed);
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _playertargetPosition[i].transform.position, Time.deltaTime * speed);

            if (_player.transform.position == _playertargetPosition[i].transform.position && _camera.transform.position == _cameratargetPosition[i].transform.position)
            {
                isMoving = false;
                player_anim.SetBool("isWalking", false);
                pai_anim.SetBool("isWalking", false);
                i++;
                textmode = true;
            }
        }
    }

    public void MoveStart()
    {
        textmode = false;
        player_anim.SetBool("isWalking", true);
        pai_anim.SetBool("isWalking", true);
        isMoving = true;
    }

    public void PlayerSad()
    {
        player_anim.SetBool("Sad", true);
    }

    public void PlayerTalk()
    {
        player_anim.SetBool("isTalking", true);
    }

    public void PlayerNotTalk()
    {
        player_anim.SetBool("isTalking", false);
    }

    public void PlayerStudy()
    {
        player_anim.SetBool("isStudying", true);
    }

    public void PlayerNotStudy()
    {
        player_anim.SetBool("isStudying", false);
    }

    //페이몬
    public void PaimonSad()
    {
        pai_anim.SetBool("Sad", true);        
        Debug.Log("슬픈 페이몬");
    }
    
    public void PaimonFlip(bool _flip)
    {
        pai_sprite.flipX = _flip;
    }

    public void PaimonTalk()
    {
        pai_anim.SetBool("isTalking", true);
    }

    public void PaimonNotTalk()
    {
        pai_anim.SetBool("isTalking", false);
    }

    public void NotSad()
    {
        player_anim.SetBool("Sad", false);
        pai_anim.SetBool("Sad", false);

    }
    public void PaimonStar()
    {
        pai_anim.SetBool("Star", true);
    }

    public void PaimonNotStar()
    {
        pai_anim.SetBool("Star", false);
    }
}
