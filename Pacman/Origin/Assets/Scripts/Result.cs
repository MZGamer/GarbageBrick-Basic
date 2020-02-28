using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {
    public Text Score, useTime, Res;
    public static int HighScore, passlevel, totalkill;
    public int oldHi, oldpass, oldkill, oldtime, death,time, useball=0,olddeath,olduse;

    public bool flag = false;
    [Header("成就")]
    public GameObject[] ach = new GameObject[3];
    public GameObject lastword;
    [Header("成就提醒1")]
    public Text achname01, achinf01;
    public bool scorechk = false;
    public bool using01 = false;
    [Header("成就提醒2")]
    public Text achname02, achinf02;
    public bool levelchk = false;
    public bool using02 = false;
    [Header("成就提醒3")]
    public Text achname03, achinf03;
    public bool killchk = false;
    public bool using03 = false;
    [Header("成就提醒4")]
    public Text achname04, achinf04;
    public bool deathchk = false;
    public bool using04 = false;
    [Header("成就提醒5")]
    public Text achname05, achinf05;
    public bool timechk = false;
    public bool using05 = false;
    [Header("成就提醒6")]
    public Text achname06, achinf06;
    public bool ballchk = false;
    public bool using06 = false;
    // Use this for initialization
    void Start () {
        oldHi = PlayerPrefs.GetInt("Highscore");
        oldpass = PlayerPrefs.GetInt("passlevel");
        totalkill = PlayerPrefs.GetInt("kill");
        oldkill = totalkill;
        olddeath = PlayerPrefs.GetInt("death");
        oldtime = PlayerPrefs.GetInt("time");
        time = (int)ScoreMan.usetime;
        olduse = PlayerPrefs.GetInt("useball");


    
        Score.text = "Your Score:" + ScoreMan.score;
        useTime.text = "Survive Time:" + (int)ScoreMan.usetime;
        Res.text = "Result:" + (ScoreMan.score * 2 + (int)ScoreMan.usetime*5)/2;
        death = olddeath + 1;
        Debug.Log(death);
        useball = attack.useball - fireball.kill;



        if (HighScore < (ScoreMan.score * 2 + (int)ScoreMan.usetime*5)/2)
        {
            HighScore = ((ScoreMan.score * 2 + (int)ScoreMan.usetime*5)/2);
            PlayerPrefs.SetInt("Highscore", HighScore);
        }
        if (PlayerPrefs.GetInt("passlevel")<passlevel)
            PlayerPrefs.SetInt("passlevel", passlevel);
        totalkill += fireball.kill;
        fireball.kill = 0;
        PlayerPrefs.SetInt("kill", totalkill);
        PlayerPrefs.SetInt("death", death);
        if (oldtime < (int)ScoreMan.usetime)
            PlayerPrefs.SetInt("time", (int)ScoreMan.usetime);
        PlayerPrefs.SetInt("useball", useball);
        ach1chk();
        ach2chk();
        ach3chk();
        ach4chk();
        ach5chk();
        ach6chk();


        aniplay();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ach1chk()
    {
        flag = false;
        if (oldHi<2500 && HighScore >= 2500)
        {
            achname01.text = "A級吃豆人";
            achinf01.text = "最終分數2500以上";
            scorechk = true;
            using01 = true;

        }
        else if (oldHi <2000 && HighScore >= 2000)
        {
            achname01.text = "B級吃豆人";
            achinf01.text = "最終分數2000以上";
            scorechk = true;
            using01 = true;
        }
        else if (oldHi <1500 && HighScore >= 1500)
        {
            achname01.text = "C級吃豆人";
            achinf01.text = "最終分數1500以上";
            scorechk = true;
            using01 = true;
        }
        else if (oldHi < 1000 && HighScore >= 1000)
        {
            achname01.text = "D級吃豆人";
            achinf01.text = "最終分數1000以上";
            scorechk = true;
            using01 = true;
        }
        else if (oldHi <500 && HighScore >= 500)
        {
            achname01.text = "E級吃豆人";
            achinf01.text = "最終分數500以上";
            scorechk = true;
            using01 = true;
        }




        else if (oldpass < 5 && passlevel > 4)
        {
            achname01.text = "吃豆人傳奇";
            achinf01.text = "通過等級5";
            levelchk = true;
            using01 = true;
        }
        else if (oldpass < 4 && passlevel > 3)
        {
            achname01.text = "地獄冒險者";
            achinf01.text = "通過等級4";
            levelchk = true;
            using01 = true;
        }
        else if (oldpass < 3 && passlevel > 2)
        {
            achname01.text = "吃豆人";
            achinf01.text = "通過等級3";
            levelchk = true;
            using01 = true;
        }
        else if (oldpass < 2 && passlevel > 1)
        {
            achname01.text = "存活者";
            achinf01.text = "通過等級2";
            levelchk = true;
            using01 = true;
        }
        else if (oldpass < 1 && passlevel > 0)
        {
            achname01.text = "生存新手";
            achinf01.text = "通過等級1";
            levelchk = true;
            using01 = true;
        }



        else if (oldkill < 10 && totalkill > 9)
        {
            achname01.text = "單生大賢者";
            achinf01.text = "總計消滅10隻鬼";
            killchk = true;
            using01 = true;
        }
        else if (oldkill < 7 && totalkill > 6)
        {
            achname01.text = "太陽術師";
            achinf01.text = "總計消滅7隻鬼";
            killchk = true;
            using01 = true;
        }
        else if (oldkill < 5 && totalkill > 4)
        {
            achname01.text = "火球操弄者";
            achinf01.text = "總計消滅5隻鬼";
            killchk = true;
            using01 = true;
        }
        else if (oldkill < 3 && totalkill > 2)
        {
            achname01.text = "高級魔法師";
            achinf01.text = "總計消滅3隻鬼";
            killchk = true;
            using01 = true;
        }
        else if (oldkill < 1 && totalkill > 0)
        {
            achname01.text = "見習魔法師";
            achinf01.text = "總計消滅1隻鬼";
            killchk = true;
            using01 = true;
        }
    }
    void ach2chk()
    {
        if (levelchk != true && killchk !=true)
        {

            if (oldpass < 5 && passlevel > 4)
            {
                achname02.text = "吃豆人傳奇";
                achinf02.text = "通過等級5";
                levelchk = true;
                using02 = true;
            }
            else if (oldpass < 4 && passlevel > 3)
            {
                achname02.text = "地獄冒險者";
                achinf02.text = "通過等級4";
                levelchk = true;
                using02 = true;
            }
            else if (oldpass < 3 && passlevel > 2)
            {
                achname02.text = "吃豆人";
                achinf02.text = "通過等級3";
                levelchk = true;
                using02 = true;
            }
            else if (oldpass < 2 && passlevel > 1)
            {
                achname02.text = "存活者";
                achinf02.text = "通過等級2";
                levelchk = true;
                using02 = true;
            }
            else if (oldpass < 1 && passlevel > 0)
            {
                achname02.text = "生存新手";
                achinf02.text = "通過等級1";
                levelchk = true;
                using02 = true;
            }
            else if (oldkill < 10 && totalkill > 9)
            {
                achname02.text = "單生大賢者";
                achinf02.text = "總計消滅10隻鬼";
                killchk = true;
                using02 = true;
            }
            else if (oldkill < 7 && totalkill > 6)
            {
                achname02.text = "太陽術師";
                achinf02.text = "總計消滅7隻鬼";
                killchk = true;
                using02 = true;
            }
            else if (oldkill < 5 && totalkill > 4)
            {
                achname02.text = "火球操弄者";
                achinf02.text = "總計消滅5隻鬼";
                killchk = true;
                using02 = true;
            }
            else if (oldkill < 3 && totalkill > 2)
            {
                achname02.text = "高級魔法師";
                achinf02.text = "總計消滅3隻鬼";
                killchk = true;
                using02 = true;
            }
            else if (oldkill < 1 && totalkill > 0)
            {
                achname02.text = "見習魔法師";
                achinf02.text = "總計消滅1隻鬼";
                killchk = true;
                using02 = true;
            }
        }
        else if (levelchk && killchk != true)
        {
            if (oldkill < 10 && totalkill > 9)
            {
                achname02.text = "單生大賢者";
                achinf02.text = "總計消滅10隻鬼";
                killchk = true;
                using02 = true;
            }
            else if (oldkill < 7 && totalkill > 6)
            {
                achname02.text = "太陽術師";
                achinf02.text = "總計消滅7隻鬼";
                killchk = true;
                using02 = true;
            }
            else if (oldkill < 5 && totalkill > 4)
            {
                achname02.text = "火球操弄者";
                achinf02.text = "總計消滅5隻鬼";
                killchk = true;
                using02 = true;
            }
            else if (oldkill < 3 && totalkill > 2)
            {
                achname02.text = "高級魔法師";
                achinf02.text = "總計消滅3隻鬼";
                killchk = true;
                using02 = true;
            }
            else if (oldkill < 1 && totalkill > 0)
            {
                achname02.text = "見習魔法師";
                achinf02.text = "總計消滅1隻鬼";
                killchk = true;
                using02 = true;
            }
        }
    }
    void ach3chk()
    {
        flag = false;
        if (killchk != true)
        {
            if (oldkill < 10 && totalkill > 9)
            {
                achname03.text = "單生大賢者";
                achinf03.text = "總計消滅10隻鬼";
                killchk = true;
                using03 = true;
            }
            else if (oldkill < 7 && totalkill > 6)
            {
                achname03.text = "太陽術師";
                achinf03.text = "總計消滅7隻鬼";
                killchk = true;
                using03 = true;
            }
            else if (oldkill < 5 && totalkill > 4)
            {
                achname03.text = "火球操弄者";
                achinf03.text = "總計消滅5隻鬼";
                killchk = true;
                using03 = true;
            }
            else if (oldkill < 3 && totalkill > 2)
            {
                achname03.text = "高級魔法師";
                achinf03.text = "總計消滅3隻鬼";
                killchk = true;
                using03 = true;
            }
            else if (oldkill < 1 && totalkill > 0)
            {
                achname03.text = "見習魔法師";
                achinf03.text = "總計消滅1隻鬼";
                killchk = true;
                using03 = true;
            }
        }

    }

    void ach4chk()
    {
        if (death>8 && olddeath < 9)
        {
            achname04.text = "閻羅王之使者";
            achinf04.text = "總計死亡9次以上";
            deathchk = true;
            using04 = true;
        }
        else if (death > 6 && olddeath < 7)
        {
            achname04.text = "......";
            achinf04.text = "總計死亡7次以上";
            deathchk = true;
            using04 = true;
        }
        else if (death > 4 && olddeath < 5)
        {
            achname04.text = "咒怨幽魂";
            achinf04.text = "總計死亡5次以上";
            deathchk = true;
            using04 = true;
        }
        else if (death > 2 && olddeath < 3)
        {
            achname04.text = "歸怨幽魂";
            achinf04.text = "總計死亡3次以上";
            deathchk = true;
            using04 = true;
        }
        else if (death > 0 && olddeath < 1)
        {
            achname04.text = "徘徊幽魂";
            achinf04.text = "總計死亡1次以上";
            deathchk = true;
            using04 = true;
        }
        else if (time >= 300 && oldtime < 300)
        {
            achname04.text = "地獄徘徊者";
            achinf04.text = "存活時間超過300秒";
            timechk = true;
            using04 = true;
        }
        else if (time >= 250 && oldtime < 250)
        {
            achname04.text = "......";
            achinf04.text = "存活時間超過250秒";
            timechk = true;
            using04 = true;
        }
        else if (time >= 200 && oldtime < 200)
        {
            achname04.text = "絕望者";
            achinf04.text = "存活時間超過200秒";
            timechk = true;
            using04 = true;
        }
        else if (time >= 100 && oldtime < 100)
        {
            achname04.text = "到訪者";
            achinf04.text = "存活時間超過100秒";
            timechk = true;
            using04 = true;
        }
        else if (time >= 50 && oldtime < 50)
        {
            achname04.text = "初入地獄";
            achinf04.text = "存活時間超過50秒";
            timechk = true;
            using04 = true;
        }
        else if(olduse<15 && useball > 14)
        {
            achname04.text = "絕望求生者";
            achinf04.text = "累積火球落空15次";
            ballchk = true;
            using04 = true;
        }
        else if (olduse < 12 && useball > 11)
        {
            achname04.text = "......";
            achinf04.text = "累積火球落空12次";
            ballchk = true;
            using04 = true;
        }
        else if (olduse < 9 && useball > 8)
        {
            achname04.text = "絕命求生者";
            achinf04.text = "累積火球落空9次";
            ballchk = true;
            using04 = true;
        }
        else if (olduse < 6 && useball > 5)
        {
            achname04.text = "掙扎求生";
            achinf04.text = "累積火球落空6次";
            ballchk = true;
            using04 = true;
        }
        else if (olduse < 3 && useball > 2)
        {
            achname04.text = "菜鳥魔法師";
            achinf04.text = "累積火球落空3次";
            ballchk = true;
            using04 = true;
        }
    }
    void ach5chk()
    {
        if (timechk != true && ballchk !=true)
        {
            if (time >= 300 && oldtime < 300)
            {
                achname05.text = "地獄徘徊者";
                achinf05.text = "存活時間超過300秒";
                timechk = true;
                using05 = true;
            }
            else if (time >= 250 && oldtime < 250)
            {
                achname05.text = "......";
                achinf05.text = "存活時間超過250秒";
                timechk = true;
                using05 = true;
            }
            else if (time >= 200 && oldtime < 200)
            {
                achname05.text = "絕望者";
                achinf05.text = "存活時間超過200秒";
                timechk = true;
                using05 = true;
            }
            else if (time >= 100 && oldtime < 100)
            {
                achname05.text = "到訪者";
                achinf05.text = "存活時間超過100秒";
                timechk = true;
                using05 = true;
            }
            else if (time >= 50 && oldtime < 50)
            {
                achname05.text = "初入地獄";
                achinf05.text = "存活時間超過50秒";
                timechk = true;
                using05 = true;
            }
           else if (olduse < 15 && useball > 14)
            {
                achname05.text = "絕望求生者";
                achinf05.text = "累積火球落空15次";
                ballchk = true;
                using05 = true;
            }
            else if (olduse < 12 && useball > 11)
            {
                achname05.text = "......";
                achinf05.text = "累積火球落空12次";
                ballchk = true;
                using05 = true;
            }
            else if (olduse < 9 && useball > 8)
            {
                achname05.text = "絕命求生者";
                achinf05.text = "累積火球落空9次";
                ballchk = true;
                using05 = true;
            }
            else if (olduse < 6 && useball > 5)
            {
                achname05.text = "掙扎求生";
                achinf05.text = "累積火球落空6次";
                ballchk = true;
                using05 = true;
            }
            else if (olduse < 3 && useball > 2)
            {
                achname05.text = "菜鳥魔法師";
                achinf05.text = "累積火球落空3次";
                ballchk = true;
                using05 = true;
            }
        }
        else if (timechk && ballchk != true)
        {
            if (olduse < 15 && useball > 14)
            {
                achname05.text = "絕望求生者";
                achinf05.text = "累積火球落空15次";
                ballchk = true;
                using05 = true;
            }
            else if (olduse < 12 && useball > 11)
            {
                achname05.text = "......";
                achinf05.text = "累積火球落空12次";
                ballchk = true;
                using05 = true;
            }
            else if (olduse < 9 && useball > 8)
            {
                achname05.text = "絕命求生者";
                achinf05.text = "累積火球落空9次";
                ballchk = true;
                using05 = true;
            }
            else if (olduse < 6 && useball > 5)
            {
                achname05.text = "掙扎求生";
                achinf05.text = "累積火球落空6次";
                ballchk = true;
                using05 = true;
            }
            else if (olduse < 3 && useball > 2)
            {
                achname05.text = "菜鳥魔法師";
                achinf05.text = "累積火球落空3次";
                ballchk = true;
                using05 = true;
            }
        }
    }
    void ach6chk()
    {
        if (ballchk != true)
        {
            if (olduse < 15 && useball > 14)
            {
                achname06.text = "地獄徘徊者";
                achinf06.text = "累積火球落空15次";
                ballchk = true;
                using06 = true;
            }
            else if (olduse < 12 && useball > 11)
            {
                achname06.text = "......";
                achinf06.text = "累積火球落空12次";
                ballchk = true;
                using06 = true;
            }
            else if (olduse < 9 && useball > 8)
            {
                achname06.text = "絕命求生者";
                achinf06.text = "累積火球落空9次";
                ballchk = true;
                using06 = true;
            }
            else if (olduse < 6 && useball > 5)
            {
                achname06.text = "掙扎求生";
                achinf06.text = "累積火球落空6次";
                ballchk = true;
                using06 = true;
            }
            else if (olduse < 3 && useball > 2)
            {
                achname06.text = "菜鳥魔法師";
                achinf06.text = "累積火球落空3次";
                ballchk = true;
                using06 = true;
            }
        }
    }

    void aniplay()
    {
        if (using01)
        {
            ach[0].SetActive(true);
            lastword.SetActive(true);
        }
        if (using02)
        {
            ach[1].SetActive(true);
        }
        if (using03)
        {
            ach[2].SetActive(true);
        }
        if (using04)
        {
            lastword.SetActive(true);
            ach[3].SetActive(true);
        }
        if (using05)
        {
            ach[4].SetActive(true);
        }
        if (using06)
        {
            ach[5].SetActive(true);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("start");
    }
}
