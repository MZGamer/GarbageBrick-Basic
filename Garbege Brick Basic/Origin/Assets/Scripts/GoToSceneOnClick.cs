using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToSceneOnClick : MonoBehaviour
{
    int check = 0;
    public Animator StarAni;
    public GameObject Space;


    public void Update()
    {
        if(check ==0)
        GameStart();
        if(check == 1)
            Space.SetActive(false);
    }
    public void GameStart()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Space.SetActive(false);
            check = 1;
            StarAni.SetBool("Start", true);
            Invoke("Gate", 3);
        }

    }
    public void Gate()
    {
        SceneManager.LoadScene("Gate");
    }
}