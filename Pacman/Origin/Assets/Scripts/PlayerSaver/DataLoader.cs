using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataLoader : MonoBehaviour {
    public static int HighScore,passlevel,kill,death,time,ball;
    public int level;
    public Text HS;
    public string start;
	// Use this for initialization
	void Start () {

        HighScore = PlayerPrefs.GetInt("Highscore");
        Result.HighScore = HighScore;
        HS.text = "HighScore:" + HighScore;
        passlevel = PlayerPrefs.GetInt("passlevel");
        level = passlevel;
        kill = PlayerPrefs.GetInt("kill");

        death = PlayerPrefs.GetInt("death");
        time = PlayerPrefs.GetInt("time");
        ball = PlayerPrefs.GetInt("useball");
    }
	
	// Update is called once per frame
	void Update () {
        firstset();
    }
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
        attack.useball = 0;
        fireball.kill = 0;
        SceneManager.LoadScene(start);
        PlayerPrefs.SetString("Name1", "排行榜守門員");
        PlayerPrefs.SetString("Name2", "排行榜守門員");
        PlayerPrefs.SetString("Name3", "排行榜守門員");
        PlayerPrefs.SetString("Name4", "排行榜守門員");
        PlayerPrefs.SetString("Name5", "排行榜守門員");
        PlayerPrefs.SetString("Name6", "排行榜守門員");
        PlayerPrefs.SetString("Name7", "排行榜守門員");
        PlayerPrefs.SetString("Name8", "排行榜守門員");
        PlayerPrefs.SetInt("No1", 200);
        PlayerPrefs.SetInt("No2", 200);
        PlayerPrefs.SetInt("No3", 200);
        PlayerPrefs.SetInt("No4", 200);
        PlayerPrefs.SetInt("No5", 200);
        PlayerPrefs.SetInt("No6", 200);
        PlayerPrefs.SetInt("No7", 200);
        PlayerPrefs.SetInt("No8", 200);
    }
    public void firstset()
    {
        if (PlayerPrefs.GetInt("HasSet") == 0)
        {
            Delete();
            PlayerPrefs.SetInt("HasSet", 1);
            Debug.Log("Game has completed the first Set");
        }
    }
}
