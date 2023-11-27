using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject Anim;

    Animator ani;
    // Start is called before the first frame update
    void Awake()
    {
        ani = Anim.GetComponent<Animator>();
    }
    private void Start()
    {
        ani.SetBool("Move", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
