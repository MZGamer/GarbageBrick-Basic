using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArcPlayerRespawn : MonoBehaviour {

    public float timer;
    public int life,Tips;
    public Text Life, CD,tipview;
    public string[] TipsList = new string[10];

	// Use this for initialization
	void Start () {
        timer = 0;
        Tipschanger();
        life = 3 - ArcadeScoreMan.deadcount - 1;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        UIchange();
        ScenceChange();

    }

    public void UIchange()
    {
        Life.text = "X " + life;
        CD.text = "" + (5 - (int)timer);
    }
    public void ScenceChange()
    {
        if (5 - (int)timer == 0)
            SceneManager.LoadScene("ArcadeMode");
    }
    public void Tipschanger()
    {
        Tips = Random.Range(0, 10);
        tipview.text = "Tips:" + TipsList[Tips];

    }
}
