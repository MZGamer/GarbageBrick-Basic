using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalResult : MonoBehaviour {
    [Header("SongInf1")]
    public Text SongName1;
    public Text Author1;
    public Text Score1;
    public Image SongBG1;
    [Header("SongInf2")]
    public Text SongName2;
    public Text Author2;
    public Text Score2;
    public Image SongBG2;
    [Header("SongInf3")]
    public Text SongName3;
    public Text Author3;
    public Text Score3;
    public Image SongBG3;
    // Use this for initialization
    void Start () {
        SongInf();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SongInf()
    {
        SongName1.text = Score.SongNameSaver[1];
        Author1.text = Score.SongAuthorSaver[1];
        Score1.text = ""+Score.ScoreSaver[1];
        SongBG1.sprite = Score.SongImageSaver[1];

        SongName2.text = Score.SongNameSaver[2];
        Author2.text = Score.SongAuthorSaver[2];
        Score2.text = "" + Score.ScoreSaver[2];
        SongBG2.sprite = Score.SongImageSaver[2];

        SongName3.text = Score.SongNameSaver[3];
        Author3.text = Score.SongAuthorSaver[3];
        Score3.text = "" + Score.ScoreSaver[3];
        SongBG3.sprite = Score.SongImageSaver[3];
    }
}
