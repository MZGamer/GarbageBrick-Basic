using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EmptySong : MonoBehaviour {
    [Header("測試用參數(神的恩惠)")]
    public float st_time = 5f;
    public float[] inv_time;
    public string[] fname;
    [Header("譜面")]
    public List<GameObject> Brick = new List<GameObject>();
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


    void Start()
    {
        PlayerPrefs.SetInt("Completed", 0);
        PlayerPrefs.SetInt("isStandBy", 0);
        MusicStart = false;
        Invoke("StandingBy", 2);
        //Invoke("GameStart", 0);
        for (int i = 0; i < fname.Length; i++)
        {
            State[i].SetActive(false);
        }
        TimeBar.SetActive(false);
        TimeBarPar.SetActive(false);

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
        if (Dead.Fail != true && MusicStart && (songTime - (int)passtime) > 0)
            passtime += Time.deltaTime;
        //TTime.text = "Time: " + (songTime - (int)passtime);
        TimeBar.transform.position = new Vector3(passtime / songTime * 135 - 135f, -36f, -1);
        TimeBarPar.transform.position = new Vector3(passtime / songTime * 135 - 67f, -36f, -1);
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
        SceneManager.LoadScene("End");
    }
    // 以下為譜面

}
