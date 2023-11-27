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
    public bool step = false;
    Animator player_anim;
    Animator pai_anim;

    SpriteRenderer player_sprite;
    SpriteRenderer pai_sprite;
    private void Awake()
    {
        player_anim = _player.GetComponent<Animator>();
        pai_anim = _paimon.GetComponent<Animator>();
        pai_sprite = _paimon.GetComponent<SpriteRenderer>();
        player_sprite = _player.GetComponent<SpriteRenderer>();
    }

    public int i = 0;
    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _cameratargetPosition[i].transform.position, Time.deltaTime * speed);
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _playertargetPosition[i].transform.position, Time.deltaTime * speed);

            if (_player.transform.position == _playertargetPosition[i].transform.position && _camera.transform.position != _cameratargetPosition[i].transform.position)
            {
                player_anim.SetBool("isWalking", false);
                pai_anim.SetBool("isWalking", false);
            }

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

    public void PlayerNotSad()
    {
        player_anim.SetBool("Sad", false);
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

    public void PlayerReceive()
    {
        player_anim.SetBool("isReceving", true);
    }

    public void PlayerNotReceive()
    {
        player_anim.SetBool("isReceving", false);
    }

    public IEnumerator Working(GameObject _stepPosition, GameObject _stepPosition2, GameObject _stepPosition3, float _speed, bool _flip)
    {     
        textmode = false;
        player_anim.SetBool("isWalking", true);
        pai_anim.SetBool("isWalking", true);
        while (_player.transform.position != _stepPosition.transform.position)
        {
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _stepPosition.transform.position, Time.deltaTime * _speed);
            yield return null;
        }

        player_sprite.flipX = true;
        pai_sprite.flipX = true;
        while (_player.transform.position != _stepPosition2.transform.position)
        {          
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _stepPosition2.transform.position, Time.deltaTime * _speed);
            yield return null;
        }

        player_sprite.flipX = false;
        pai_sprite.flipX = false;
        while (_player.transform.position != _stepPosition.transform.position)
        {
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _stepPosition.transform.position, Time.deltaTime * _speed);
            yield return null;
        }

        player_sprite.flipX = true;
        pai_sprite.flipX = true;
        while (_player.transform.position != _stepPosition2.transform.position)
        {
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _stepPosition2.transform.position, Time.deltaTime * _speed);
            yield return null;
        }

        player_sprite.flipX = false;
        pai_sprite.flipX = false;
        while (_player.transform.position != _stepPosition3.transform.position)
        {
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _stepPosition3.transform.position, Time.deltaTime * 2f);
            yield return null;
        }


        textmode = true;
        player_anim.SetBool("isWalking", false);
        pai_anim.SetBool("isWalking", false);
    }

    public IEnumerator PlayerStep(GameObject _stepPosition, float _speed, bool _flip)
    {
        player_sprite.flipX = _flip;
        pai_sprite.flipX = _flip;
        textmode = false;
        player_anim.SetBool("isWalking", true);
        pai_anim.SetBool("isWalking", true);
        while (_player.transform.position != _stepPosition.transform.position)
        {
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _stepPosition.transform.position, Time.deltaTime * _speed);
            yield return null;
        }
        textmode = true;
        player_anim.SetBool("isWalking", false);
        pai_anim.SetBool("isWalking", false);
    }

    //∆‰¿Ã∏Û
    public void PaimonSad()
    {
        pai_anim.SetBool("Sad", true);        
    }

    public void PaimonNotSad()
    {
        pai_anim.SetBool("Sad", false);
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

    public void PaimonStar()
    {
        pai_anim.SetBool("Star", true);
    }

    public void PaimonNotStar()
    {
        pai_anim.SetBool("Star", false);
    }

    public void NotSad()
    {
        player_anim.SetBool("Sad", false);
        pai_anim.SetBool("Sad", false);

    }
}
