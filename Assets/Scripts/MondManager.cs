using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MondManager : MonoBehaviour
{
    public TextManager textManager;

    public PlayerMove playerMove;
    public VentiMove ventiMove;


    private void Awake()
    {
            
    }

    void Start()
    {
        playerMove.MoveStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
