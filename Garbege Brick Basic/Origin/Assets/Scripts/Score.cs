using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    
    public Text finalScoreText;
    public Image BG;
    public Text Author, Songname;
    public GameObject Bonus;
    public int CompleteCheck;
    static public int OnlineUseScore;

    public static Sprite[] SongImageSaver = new Sprite[SongSlect.MaxTrackCheck + 1];
    public static string[] SongNameSaver = new string[SongSlect.MaxTrackCheck + 1];
    public static string[] SongAuthorSaver = new string[SongSlect.MaxTrackCheck + 1];
    public static int[] ScoreSaver = new int[SongSlect.MaxTrackCheck + 1];
    // Use this for initialization
    void Start ()
    {

        CompleteCheck = PlayerPrefs.GetInt("Completed");
        BG.sprite = SongSlect.SongDataBK[SongSlect.ID-1].image;
        Author.text = SongSlect.SongDataBK[SongSlect.ID-1].Author;
        Songname.text = SongSlect.SongDataBK[SongSlect.ID-1].SongName;
        finalScoreText.text = "Score : " + PlayerPrefs.GetInt("OOO");

        SongImageSaver[SongSlect.TrackNo] = SongSlect.SongDataBK[SongSlect.ID - 1].image;
        SongNameSaver[SongSlect.TrackNo] = SongSlect.SongDataBK[SongSlect.ID - 1].SongName;
        SongAuthorSaver[SongSlect.TrackNo] = SongSlect.SongDataBK[SongSlect.ID - 1].Author;
        if(CompleteCheck ==1)
            ScoreSaver[SongSlect.TrackNo] = PlayerPrefs.GetInt("OOO") + 1000;
        else
            ScoreSaver[SongSlect.TrackNo] = PlayerPrefs.GetInt("OOO");

        SongSlect.TrackNo++;
        OnlineUseScore = ScoreSaver[SongSlect.TrackNo];
    }
    
   

    // Update is called once per frame
    void Update () {
        if (CompleteCheck == 1)
        {
            Bonus.SetActive(true);
        }

    }
}
