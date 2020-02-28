using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour {
    public GameObject[] ach = new GameObject[30];
    public GameObject achviewerp1,achviewerp2;
    public bool[] get=new bool[30];
    public bool click = false;
    public int page = 1;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 30; i++)
        {
            ach[i].gameObject.SetActive(false);
            achviewerp1.SetActive(false);
            achviewerp2.SetActive(false);
            get[i] = false;
        }
        achievecheckP1();
        achievementcheckP2();

    }
	
	// Update is called once per frame
	void Update () {
    }
    public void achievecheckP1()
    {
        highscorecheck();
        levelpasscheck();
        ghostkillcheck();
    }
    public void achievementcheckP2()
    {
        deathcheck();
        timecheck();
        ballcheck();
    }
    public void highscorecheck()
    {
        if (DataLoader.HighScore > 500)
        {
            get[0] = true;
        }
        if (DataLoader.HighScore > 1000)
        {
            get[1] = true;
        }
        if (DataLoader.HighScore > 1500)
        {
            get[2] = true;
        }
        if (DataLoader.HighScore > 2000)
        {
            get[3] = true;
        }
        if (DataLoader.HighScore > 2500)
        {
            get[4] = true;
        }
    }
    public void levelpasscheck()
    {
        if (DataLoader.passlevel > 0)
            get[5] = true;
        if (DataLoader.passlevel > 1)
            get[6] = true;
        if (DataLoader.passlevel > 2)
            get[7] = true;
        if (DataLoader.passlevel > 3)
            get[8] = true;
        if (DataLoader.passlevel > 4)
            get[9] = true;


    }
    public void ghostkillcheck()
    {
        if (DataLoader.kill > 0)
            get[10] = true;
        if (DataLoader.kill > 2)
            get[11] = true;
        if (DataLoader.kill > 4)
            get[12] = true;
        if (DataLoader.kill > 6)
            get[13] = true;
        if (DataLoader.kill > 9)
            get[14] = true;
    }
    public void deathcheck()
    {
        if (DataLoader.death > 0)
            get[15] = true;
        if (DataLoader.death > 2)
            get[16] = true;
        if (DataLoader.death > 4)
            get[17] = true;
        if (DataLoader.death > 6)
            get[18] = true;
        if (DataLoader.death > 8)
            get[19] = true;
    }
    public void timecheck()
    {
        if (DataLoader.time >= 50)
            get[20] = true;
        if (DataLoader.time >= 100)
            get[21] = true;
        if (DataLoader.time >= 200)
            get[22] = true;
        if (DataLoader.time >= 250)
            get[23] = true;
        if (DataLoader.time >= 300)
            get[24] = true;
    }
    public void ballcheck()
    {
        if (DataLoader.ball > 2)
            get[25] = true;
        if (DataLoader.ball > 5)
            get[26] = true;
        if (DataLoader.ball > 8)
            get[27] = true;
        if (DataLoader.ball > 11)
            get[28] = true;
        if (DataLoader.ball > 14)
            get[29] = true;
    }

    public void achievement_view()
    {
        if (click == false)
        {
            click = true;
            achievecheckP1();
            achviewerp1.SetActive(true);
            page1start();
        }
        else
        {
            if (page == 1)
            {
                achviewerp1.SetActive(false);
                click = false;
            }
            else
            {
                achviewerp2.SetActive(false);
                click = false;
                page = 1;
            }
        }
    }

    public void page1start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (get[i] == true)
                ach[i].SetActive(true);
        }
    }
    public void page2start()
    {
        for (int i = 15; i < 30; i++)
        {
            if (get[i] == true)
                ach[i].SetActive(true);
        }
    }

    public void changepage()
    {
        if (page == 1)
        {
            achviewerp1.SetActive(false);
            achviewerp2.SetActive(true);
            page = 2;
            page2start();
        }
        else if (page == 2)
        {
            achviewerp2.SetActive(false);
            achviewerp1.SetActive(true);
            page = 1;
            page1start();
        }
    }
}
