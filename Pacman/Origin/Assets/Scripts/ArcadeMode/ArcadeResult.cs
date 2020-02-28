using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArcadeResult : MonoBehaviour {

    public Text Score, useTime, FireBall, Result, Top;
    public GameObject OutOf,ResultMenu,TopMenu,NameInput;
    public static int result;
    public float time;
    public int[] ResTop = new int[8];
    public AudioClip MainBGM,EasterEgg;
    public AudioSource MusicPlayer;

    // Use this for initialization
    void Start () {
        BGMPlayer();
        ArcadeTop.page = 0;
        Score.text = "Score:" + ArcadeScoreMan.totalscore;
        useTime.text = "Time:" + ArcadeScoreMan.totalTime;
        FireBall.text = "FireBall:" + ArcadeScoreMan.totalfireball;
        TopMenu.SetActive(false);
        NameInput.SetActive(false);
        ResultMenu.SetActive(true);




    }
	
	// Update is called once per frame
	void Update () {
        ResultMaker();
        time += Time.deltaTime;
        Totop();

    }

    public void ResultMaker()
    {
        result = (int)(ArcadeScoreMan.totalscore * 0.8 + ArcadeScoreMan.totalTime * 3 + ArcadeScoreMan.totalfireball * 50 + ArcadeScoreMan.totalscore/5 *2);
        Result.text = "Result:" + result;
        if (ArcadeTop.newtop == 9)
        {
            OutOf.SetActive(true);
            Top.text = "8";

        }
        else
        {
            OutOf.SetActive(false);
            Top.text = "" + ArcadeTop.newtop;
        }            
    }

    public void Totop()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ArcadeTop.page == 0)
        {
            ResultMenu.SetActive(false);
            ArcadeTop.Result = true;
        }
        else if (ArcadeChecker.waitToolong)
        {
            ResultMenu.SetActive(false);
            ArcadeTop.Result = true;
        }
    }
    public void BGMPlayer()
    {
    if (ArcadeChecker.waitToolong != false)
        {
            if (Random.Range(0, 10) == 9)
                MusicPlayer.clip = EasterEgg;
            else
                MusicPlayer.clip = MainBGM;
        }
    else
        MusicPlayer.clip = MainBGM;

        MusicPlayer.Play();
    }
}
