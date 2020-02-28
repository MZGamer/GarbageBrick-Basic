using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Beatmap07 : MonoBehaviour {
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
    public Animator Camera;
    public GameObject ball;
    public GameObject player;


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
        TimeBarPar.transform.position = new Vector3(passtime / songTime * 135 - 67f, -36.5f, -1);
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
    void Stage0()
    {
        Brick[0].SetActive(true);
    }
    void Stage1()
    {
        Brick[1].SetActive(true);
    }
    void Stage2()
    {
        Destroy(Brick[0]);
        Destroy(Brick[1]);
        Brick[2].SetActive(true);
    }
    void Stage3()
    {
        Destroy(Brick[2]);
        State[0].SetActive(true);
        Brick[3].SetActive(true);
    }
    void Stage4()
    {
        Destroy(Brick[3]);
        State[1].SetActive(true);
        Brick[4].SetActive(true);
    }
    void Stage5()
    {
        Destroy(Brick[4]);
        State[2].SetActive(true);
        Brick[5].SetActive(true);
    }
    void Stage5002()
    {
        Destroy(Brick[5]);
        Destroy(State[0]);
        Destroy(State[1]);
        Destroy(State[2]);
    }
    void Stage6()
    {
        Brick[6].SetActive(true);
    }
    void Stage6002()
    {
        Destroy(Brick[6]);
    }
    void Stage6003()
    {
        Brick[7].SetActive(true);
    }
    void Stage7()
    {
        Destroy(Brick[7]);
        Brick[8].SetActive(true);
        //Maincamera.transform.localRotation(0, 0, 180);
    }
    void Stage8()
    {
        Brick[9].SetActive(true);
    }
    void Stage8002()
    {
        Camera.Play("New Animation8-2");
    }
    void Stage9()
    {
        Destroy(Brick[8]);
        Destroy(Brick[9]);
        State[4].SetActive(true);
        State[5].SetActive(true);
        State[6].SetActive(true);
        State[7].SetActive(true);
        State[8].SetActive(true);
        State[9].SetActive(true);
        State[10].SetActive(true);
        State[11].SetActive(true);
        Brick[10].SetActive(true);
    }
    void Stage10()
    {
        Brick[11].SetActive(true);
    }
    void Stage1001()
    {
        Brick[12].SetActive(true);
    }
void Stage1002()
    {
        Ball.bodyType = RigidbodyType2D.Kinematic;
        ball.transform.parent = player.transform;
        ball.transform.localPosition = new Vector2(0, 0.85f);
        player.transform.position = new Vector3(0, -35.61f, -1.56f);
        player.SetActive(false);
        Destroy(State[4]);
        Destroy(State[5]);
        Destroy(State[6]);
        Destroy(State[7]);
        Destroy(State[8]);
        Destroy(State[9]);
        Destroy(State[10]);
        Destroy(State[11]);
        Destroy(Brick[10]);
        Destroy(Brick[11]);
        State[3].SetActive(false);
        Camera.Play("New Animation8-4");
    }
    void Stage1003()
    {
        player.SetActive(true);
    }
    void Stage11()
    {
        Brick[13].SetActive(true);
    }
    void Stage12()
    {
        Brick[14].SetActive(true);
    }
    void Stage1202()
    {
        Ball.bodyType = RigidbodyType2D.Kinematic;
        ball.transform.parent = player.transform;
        ball.transform.localPosition = new Vector2(0, 0.85f);
        player.transform.position = new Vector3(0, -35.61f, -1.56f);
        player.SetActive(false);
    }
    void Stage1203()
    {
        player.SetActive(true);
        Destroy(Brick[12]);
        Destroy(Brick[13]);
        Destroy(Brick[14]);
        State[3].SetActive(true);
    }
    void Stage13()
    {
        Brick[15].SetActive(true);
    }

}
    