using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeatMap03 : MonoBehaviour {
    [Header("譜面")]
    public List<GameObject> Brick =new List <GameObject>();
    public List<GameObject> State = new List<GameObject>();
    public List<Animation> Effect = new List<Animation>();
    public int songTime;
    [Header("UI相關")]
    public Text TTime;
    public AudioSource BGM;
    [Header("計時相關")]
    public GameObject TimeBar;
    public GameObject TimeBarPar;
    public float passtime;
    public bool MusicStart = false;
    [Header("歌曲開始相關")]
    public GameObject StandBy;
    [Header("歌曲完成特效相關")]
    public GameObject Complete;
    public AudioSource CompleteSound;
    public Rigidbody2D Ball;


    void Start()
    {
        PlayerPrefs.SetInt("Completed", 0);
        PlayerPrefs.SetInt("isStandBy", 0);
        MusicStart = false;
        Invoke("StandingBy", 2);
    }
    void StandingBy()
    {
        StandBy.SetActive(true);
        Invoke("GameStart", 3);
    }
    void GameStart()
    {
        PlayerPrefs.SetInt("isStandBy", 1);
        MusicStart = true;
        Destroy(GameObject.FindGameObjectWithTag("SongSlect"));
        BGM.Play();
        passtime = 0;
        TimeBar.SetActive(true);
        TimeBarPar.SetActive(true);
        Invoke("FollowTheMusic1", 2.4f);
        Invoke("FollowTheMusic2", 2.5f);
        Invoke("FollowTheMusic3", 3.2f);
        Invoke("FollowTheMusic4", 3.3f);
        Invoke("FollowTheMusic5", 4.5f);
        Invoke("FollowTheMusic6", 4.6f);
        Invoke("FollowTheMusic7", 5.3f);
        Invoke("FollowTheMusic8", 5.4f);
        Invoke("FollowTheMusic9", 6.9f);
        Invoke("FollowTheMusic10", 9.3f);
        Invoke("FollowTheMusic11", 31f);
        Invoke("FollowTheMusic12", 33f);
        Invoke("FollowTheMusic13", 33.5f);
        Invoke("FollowTheMusic14", 35.5f);
        Invoke("FollowTheMusic15", 36f);
        Invoke("FollowTheMusic16", 37.5f);
        Invoke("FollowTheMusic17", 38.4f);
        Invoke("FollowTheMusic18", 40.2f);
        Invoke("FollowTheMusic19", 40.7f);
        Invoke("FollowTheMusic20", 50f);
        Invoke("FollowTheMusic20", 50.2f);
        Invoke("FollowTheMusic21", 50.7f);
        Invoke("FollowTheMusic22", 51.2f);
        Invoke("FollowTheMusic23", 51.7f);
        Invoke("FollowTheMusic24", 52.2f);
        Invoke("FollowTheMusic25", 52.4f);
        Invoke("FollowTheMusic26", 52.6f);
        Invoke("FollowTheMusic27", 53.1f);
        Invoke("FollowTheMusic28", 53.6f);
        Invoke("FollowTheMusic29", 54.1f);
        Invoke("FollowTheMusic30", 54.4f);
        Invoke("FollowTheMusic31", 54.7f);

        Invoke("FollowTheMusicState2Close", 69.5f);
        Invoke("FollowTheMusic32", 68f);
        Invoke("FollowTheMusic33", 70.6f);
        Invoke("FollowTheMusic34", 73.8f);
        Invoke("FollowTheMusic35", 76.4f);
        Invoke("FollowTheMusic36", 89.7f);
        Invoke("FollowTheMusic37", 91.5f);
        Invoke("FollowTheMusic38", 94f);


        Invoke("FollowTheMusic39", 103.5f);
        Invoke("FollowTheMusic40", 103.84f);
        Invoke("FollowTheMusic41", 104.18f);
        Invoke("FollowTheMusic42", 104.52f);
        Invoke("FollowTheMusic43", 104.86f);
        Invoke("FollowTheMusic44", 105.19f);
        Invoke("FollowTheMusic45", 105.53f);
        Invoke("FollowTheMusic46", 105.87f);

        Invoke("FollowTheMusic48", 107.25f);
        Invoke("FollowTheMusic49", 108.35f);
        Invoke("FollowTheMusic50", 113.06f);
        Invoke("FollowTheMusic51", 118.1f);


    }

    void Update()
    {
        if (Dead.Fail != true && MusicStart && (songTime - (int)passtime) > 0)
        {
            passtime += Time.deltaTime;
        }
        TimeBar.transform.position = new Vector3(passtime / songTime * 135 - 161f, -79f, -1);
        TimeBarPar.transform.position = new Vector3(passtime / songTime * 135 - 93f, -79f, -1);
        if (Dead.Fail)
            CancelInvoke();
        TrackComplete();
    }
    void TrackComplete()
    {
        if (songTime - (int)passtime <= 0)
        {
            Ball.velocity = new Vector2(0, 0);
            BGM.Pause();
            Complete.SetActive(true);
            PlayerPrefs.SetInt("Completed", 1);
            Invoke("LoadResult", 7.5f);
        }
    }
    void LoadResult()
    {
        if (Gate.Online && Gate.Arcade != true)
            SceneManager.LoadScene("OnlineEnd");
        else
            SceneManager.LoadScene("End");
    }

    // 以下為譜面

    void FollowTheMusic1()
    {
        Brick[0].SetActive(true);
    }
    void FollowTheMusic2()
    {
        Brick[1].SetActive(true);
    }
    void FollowTheMusic3()
    {
        Brick[2].SetActive(true);
    }
    void FollowTheMusic4()
    {
        Brick[3].SetActive(true);
    }
    void FollowTheMusic5()
    {
        Brick[4].SetActive(true);
    }
    void FollowTheMusic6()
    {
        Brick[5].SetActive(true);
    }
    void FollowTheMusic7()
    {
        Brick[6].SetActive(true);
    }
    void FollowTheMusic8()
    {
        Brick[7].SetActive(true);
    }
    void FollowTheMusic9()
    {
        Brick[8].SetActive(true);
    }
    void FollowTheMusic10()
    {
        Brick[9].SetActive(true);
    }
    void FollowTheMusic11()
    {
        State[0].SetActive(false);
        Brick[10].SetActive(true);
    }
    void FollowTheMusic12()
    {
        Brick[11].SetActive(true);
    }
    void FollowTheMusic13()
    {
        Brick[12].SetActive(true);
    }
    void FollowTheMusic14()
    {
        Brick[13].SetActive(true);
    }
    void FollowTheMusic15()
    {
        Brick[14].SetActive(true);
    }
    void FollowTheMusic16()
    {
        Brick[15].SetActive(true);
    }
    void FollowTheMusic17()
    {
        Brick[16].SetActive(true);
    }
    void FollowTheMusic18()
    {
        Brick[17].SetActive(true);
    }
    void FollowTheMusic19()
    {
        Brick[18].SetActive(true);
        Brick[19].SetActive(true);
        Brick[20].SetActive(true);
    }
    void FollowTheMusic20()
    {
        Brick[18].SetActive(false);
        Brick[19].SetActive(false);
        Brick[20].SetActive(false);
        Brick[21].SetActive(true);
        State[1].SetActive(false);
    }
    void FollowTheMusic21()
    {
        Brick[22].SetActive(true);
    }
    void FollowTheMusic22()
    {
        Brick[23].SetActive(true);
    }
    void FollowTheMusic23()
    {
        Brick[24].SetActive(true);
    }
    void FollowTheMusic24()
    {
        Brick[25].SetActive(true);
    }
    void FollowTheMusic25()
    {
        Brick[26].SetActive(true);
    }
    void FollowTheMusic26()
    {
        Brick[27].SetActive(true);
    }
    void FollowTheMusic27()
    {
        Brick[28].SetActive(true);
    }
    void FollowTheMusic28()
    {
        Brick[29].SetActive(true);
    }
    void FollowTheMusic29()
    {
        Brick[30].SetActive(true);
    }
    void FollowTheMusic30()
    {
        Brick[31].SetActive(true);
    }
    void FollowTheMusic31()
    {
        Brick[32].SetActive(true);
    }
    void FollowTheMusicState2Close()
    {
        State[2].SetActive(false);
    }
    void FollowTheMusic32()
    {
        Brick[33].SetActive(true);
        State[2].SetActive(false);
    }
    void FollowTheMusic33()
    {
        Brick[34].SetActive(true);
    }
    void FollowTheMusic34()
    {
        Brick[35].SetActive(true);
    }
    void FollowTheMusic35()
    {
        Brick[36].SetActive(true);
    }
    void FollowTheMusic36()
    {
        State[3].SetActive(false);
        Brick[37].SetActive(true);
    }
    void FollowTheMusic37()
    {
        Brick[38].SetActive(true);
    }
    void FollowTheMusic38()
    {
        Brick[39].SetActive(true);
    }
    void FollowTheMusic39()
    {
        State[4].SetActive(false);
        Brick[40].SetActive(true);
    }
    void FollowTheMusic40()
    {
        Brick[41].SetActive(true);
    }
    void FollowTheMusic41()
    {
        Brick[42].SetActive(true);
    }
    void FollowTheMusic42()
    {
        Brick[43].SetActive(true);
    }
    void FollowTheMusic43()
    {
        Brick[44].SetActive(true);
    }
    void FollowTheMusic44()
    {
        Brick[45].SetActive(true);
    }
    void FollowTheMusic45()
    {
        Brick[46].SetActive(true);
    }
    void FollowTheMusic46()
    {
        Brick[47].SetActive(true);
    }

    void FollowTheMusic48()
    {
        Brick[48].SetActive(true);
    }
    void FollowTheMusic49()
    {
        Brick[8].SetActive(false);
        Brick[9].SetActive(false);
        Brick[49].SetActive(false);
        Effect[2].Play();
        Effect[3].Play();
    }
    void FollowTheMusic50()
    {
        Brick[49].SetActive(true);
    }
    void FollowTheMusic51()
    {
        Brick[48].SetActive(false);
    }
}
