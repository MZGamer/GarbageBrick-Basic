using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArcadeChecker : MonoBehaviour {
    public GameObject Bottom, Text,Achieve,Reset,totouralAsk,book;
    public static bool ArcMode = true , waitToolong;
    public string playing;
    public float timming = 0;

    // Use this for initialization
    void Start () {
        ArcadeScoreMan.deadcount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        ArcEnter();
        ArcStart();
        if (Input.GetKeyDown(KeyCode.Escape))
            totouralAsk.SetActive(false);
        if (PlayerPrefs.GetInt("Totoural") != 1)
            book.SetActive(false);
        timming += Time.deltaTime;
        waittoolong();


    }

    public void ArcEnter()
    {
        if (Input.GetKeyDown(KeyCode.A)&& ArcMode == false)
        {
            Bottom.SetActive(false);
            Achieve.SetActive(false);
            Reset.SetActive(false);
            Text.SetActive(true);
            book.SetActive(false);
            ArcMode = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && ArcMode)
        {
            Bottom.SetActive(true);
            Achieve.SetActive(true);
            Reset.SetActive(true);
            Text.SetActive(false);
            book.SetActive(true);
            ArcMode = false;
        }
        else if (ArcMode)
        {
            Bottom.SetActive(false);
            Achieve.SetActive(false);
            Reset.SetActive(false);
            Text.SetActive(true);
            book.SetActive(false);
            ArcMode = true;
        }
    }

    public void ArcStart()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& ArcMode && timming >= 1)
        {
            totouralAsk.SetActive(true);
            ArcadeScoreMan.totalscore = 0;
            ArcadeScoreMan.totalTime = 0;
            ArcadeScoreMan.totalfireball = 0;
            timming = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            totouralAsk.SetActive(false);
            timming = 0;
        }
    }
    public void Entertotoural()
    {
        SceneManager.LoadScene("Totoural");
        if(ArcMode != true)
        {
            PlayerPrefs.SetInt("Totoural", 1);
        }
    }
    public void Entergame()
    {
        if (ArcadeChecker.ArcMode)
            SceneManager.LoadScene("ArcadeMode");
        else
        {
            if (PlayerPrefs.GetInt("Totoural") == 1)
                totouralAsk.SetActive(false);
            else
            {
                SceneManager.LoadScene("test'");
                PlayerPrefs.SetInt("Totoural", 1);
            }
        }

    }
    public void NormalGame()
    {
        if (PlayerPrefs.GetInt("Totoural") == 1)
        {
            SceneManager.LoadScene("test'");
        }
        else
        { 
            totouralAsk.SetActive(true);
        }
    }
    public void totouralask()
    {
        totouralAsk.SetActive(true);
    }

    public void waittoolong()
    {
        if (timming > 45 && ArcMode)
        {
            waitToolong = true;
            SceneManager.LoadScene("ArcResult");
        }
    }

}
