using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentiMove : MonoBehaviour
{
    public GameObject _Venti;
    public GameObject _VentitargetPosition;

    public float speed = 2f;
    public bool isMoving = false;
    public bool textmode = true;

    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = _Venti.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            _Venti.transform.position = Vector3.MoveTowards(_Venti.transform.position, _VentitargetPosition.transform.position, Time.deltaTime * speed);

            if (_Venti.transform.position == _VentitargetPosition.transform.position)
            {
                isMoving = false;
                anim.SetBool("isWalking", false);
                textmode = true;
            }
        }
    }

    public void VentiAppear()
    {
        textmode = false;
        anim.SetBool("isWalking", true);
        isMoving = true;
    }

    public void VentiTalk()
    {
        anim.SetBool("isTalking", true);
    }

    public void VentiNotTalk()
    {
        anim.SetBool("isTalking", false);
    }
}
