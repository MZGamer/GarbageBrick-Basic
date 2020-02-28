using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [Header("測試用參數(神的恩惠)")]
    public float st_time;
    public float[] inv_time;
    public string[] fname;
    [Header("譜面")]
    public List<GameObject> Brick = new List<GameObject>();
    public List<GameObject> State = new List<GameObject>();
    public List<Animation> Effect = new List<Animation>();
    public GameObject Text, TutorialComplete;
    public int songTime;
    [Header("UI相關")]
    public Text TTime;
    public AudioSource BGM;
    [Header("計時相關")]
    public float passtime;
    public GameObject TimeBar;
    public bool MusicStart = false;
    [Header("歌曲開始相關")]
    public GameObject StandBy;
    [Header("歌曲完成特效相關")]
    public GameObject Complete;
    public AudioSource CompleteSound;
    public Rigidbody2D Ball;


    void Start()
    {
        passtime = 0;
        PlayerPrefs.SetInt("Completed", 0);
        PlayerPrefs.SetInt("isStandBy", 0);
        MusicStart = false;
        Invoke("StandingBy", 2);
        Dead.Fail = false;
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
        if (MusicStart)
            passtime += Time.deltaTime;

        if ((songTime - (int)passtime) >= 0){
            TTime.text = "Time: " + (songTime - (int)passtime);
        TimeBar.transform.localScale = new Vector2(passtime / songTime, 1);
        }

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
            State[3].SetActive(false);
            Invoke("TutorialDone", 3f);
        }
    }
    void TutorialDone()
    {
        TutorialComplete.SetActive(true);
        Invoke("LoadResult", 21f);
    }
    void LoadResult()
    {
        SceneManager.LoadScene("SongSlect");
    }

    // 以下為譜面

    void Map1()
    {
        Text.SetActive(true);
    }
    void Map2()
    {
        State[0].SetActive(true);
    }
    void Map3()
    {
        State[1].SetActive(true);
    }
    void Map4()
    {
        State[2].SetActive(true);
    }
    void Map5()
    {

    }
    void Map6()
    {
        State[0].SetActive(false);
        State[1].SetActive(false);
        State[2].SetActive(false);
        State[3].SetActive(true);
    }

}
