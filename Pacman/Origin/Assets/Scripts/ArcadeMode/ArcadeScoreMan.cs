using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArcadeScoreMan : MonoBehaviour
{
    //進行分數的計算
    public static int score,deadcount;
    public static float usetime;
    public static int pac = 332;
    public int pacdotnow;
    public string gg,play;
    public Text Score, useTime;

    public static int totalscore;
    public static int totalTime;
    public static int totalfireball;
    // Update is called once per frame
    private void Start()
    {
        fireball.kill = 0;
        GhostMove.gg = false;
        score = 0;
        usetime = 0;
        attack.fireball_amount = 2;
    }
    void FixedUpdate()
    {
        pacdotnow = pac;
        usetime += Time.deltaTime;
        Score.text = "Score:" + score;
        useTime.text = "Time" + (int)usetime;
        GameOver();

    }

    void GameOver()
    {
        if (GhostMove.gg)
        {
            deadcount++;
            totalscore += score;
            totalTime += (int)usetime;
            totalfireball += attack.fireball_amount;

            if (deadcount == 3)
                SceneManager.LoadScene(gg);
            else
                SceneManager.LoadScene(play);


        }

    }
}
