using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreMan : MonoBehaviour
{
    //進行分數的計算
    public static int score;
    public static float usetime;
    public static int pac=332;
    public int pacdotnow;
    public string gg;
    public Text Score,useTime;
    // Update is called once per frame
    private void Start()
    {
        fireball.kill = 0;
        GhostMove.gg = false;
        score = 0;
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
            SceneManager.LoadScene(gg);
        
    }
}
