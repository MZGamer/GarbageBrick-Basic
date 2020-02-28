using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeatMap05 : MonoBehaviour {
    [Header("測試用參數(神的恩惠)")]
    public float st_time = 5f;
    public float[] inv_time;
    public string[] fname;
    [Header("譜面")]
    public List<GameObject> Brick =new List <GameObject>();
    public List<GameObject> State = new List<GameObject>();
    public List<Animation> Effect = new List<Animation>();
    public int songTime;
    [Header("UI相關")]
    public Text TTime;
    public AudioSource BGM;
    [Header("計時相關")]
    public float passtime;
    public bool MusicStart = false;
    public GameObject TimeBar;
    public GameObject TimeBarPar;
    [Header("歌曲開始相關")]
    public GameObject StandBy;
    [Header("歌曲完成特效相關")]
    public GameObject Complete;
    public AudioSource CompleteSound;
    public Rigidbody2D Ball;
    [Header("譜面特效相關")]
    public GameObject ball;
    public GameObject player;
    public List<GameObject> Wall = new List<GameObject>();
    public Vector2 Speed;


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

        //Invoke譜面
        BGM.time = st_time;
        passtime = st_time;
        BGM.Play();
        for (int i = 0; i < fname.Length; i++)
        {
            if (inv_time[i] >= st_time)
            {
                Invoke(fname[i], inv_time[i] - st_time);
            }
        }


    }

    void Update()
    {
        if (Dead.Fail != true && MusicStart && (songTime - (int)passtime)>0)
            passtime += Time.deltaTime;

        TimeBar.transform.position = new Vector3(passtime / songTime * 135 - 135f, -37f, -1);
        TimeBarPar.transform.position = new Vector3(passtime / songTime * 135 - 67f, -37f, -1);
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

    void Map01()
    {
        State[0].SetActive(true);
    }
    void Map02()
    {
        Ball.velocity = Vector2.zero;
    }
    void Map03()
    {
        Ball.bodyType = RigidbodyType2D.Kinematic;
        ball.transform.parent = player.transform;
        ball.transform.localPosition = new Vector2(0, 0.85f);
        player.transform.position = new Vector3(0, -35.61f, -1.56f);
        player.SetActive(false);
        Wall[0].SetActive(false);
    }
    void Map04()
    {
        Wall[1].SetActive(true);
        player.SetActive(true);
        State[0].SetActive(false);
        State[1].SetActive(true);
    }

    void Map05()
    {
        State[1].SetActive(false);
    }
    void Map06()
    {

        State[2].SetActive(true);
    }
    void Map07()
    {
        State[3].SetActive(true);
        State[2].SetActive(false);
    }
    void Map08()
    {
        Speed = Ball.velocity;
        Ball.velocity = new Vector2(0, 0);
    }
    void Map09()
    {
        State[3].SetActive(false);
        State[4].SetActive(true);
        Ball.velocity = Speed;
    }
    void Map10()
    {
        Speed = Ball.velocity;
        Ball.velocity = new Vector2(0, 0);
    }
    void Map11()
    {
        Ball.velocity = Speed;
    }
    void Map12()
    {
        State[4].SetActive(false);
        State[5].SetActive(true);
    }
    void Map13()
    {
        State[5].SetActive(false);
        State[6].SetActive(true);
    }
    void Map14()
    {
        State[6].SetActive(false);
        State[7].SetActive(true);
    }
    void MapBallStop()
    {
    }
}
