using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public GameObject _player;
    public GameObject _paimon;
    public GameObject _playertargetPosition;

    public GameObject _camera;
    public GameObject _cameratargetPosition;

    public float speed = 2f;
    public bool isButton = false;

    Animator player_anim;
    Animator pai_anim;
    private void Awake()
    {
        player_anim = _player.GetComponent<Animator>();
        pai_anim = _paimon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isButton == true)
        {
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _cameratargetPosition.transform.position, Time.deltaTime * speed);
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _playertargetPosition.transform.position, Time.deltaTime * speed);
            
            if (_player.transform.position == _playertargetPosition.transform.position)
            {
                isButton = false;
                player_anim.SetBool("isWalking", false);
                pai_anim.SetBool("isWalking", false);
            }
        }
    }

    public void MoveStart()
    {
        player_anim.SetBool("isWalking", true);
        pai_anim.SetBool("isWalking", true);
        isButton = true;
        

    }
}
