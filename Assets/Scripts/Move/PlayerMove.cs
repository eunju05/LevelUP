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

    public Sprite _sadpaimon;
    public float speed = 2f;
    public bool isMoving = false;

    public bool textmode = false;

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

            if (_player.transform.position == _playertargetPosition[i].transform.position)
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

    public void PaimonSad()
    {
        pai_sprite.sprite = _sadpaimon;
    }

    public void PaimonStar()
    {

    }
}
