using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeatMap04 : MonoBehaviour {
    [Header("測試用參數(神的恩惠)")]
    public float st_time = 5f;
    public float[] inv_time;
    [Header("譜面")]
    public List<GameObject> Brick =new List <GameObject>();
    public List<GameObject> State = new List<GameObject>();
    public List<Animator> Effect = new List<Animator>();
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

    //譜面撥放
    public string[] fname;



    void Start()
    {
        PlayerPrefs.SetInt("Completed", 0);
        PlayerPrefs.SetInt("isStandBy", 0);
        MusicStart = false;
        Invoke("StandingBy", 2);
#if UNITY_EDITOR

#else

#endif
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
        passtime = 0;
        TimeBar.SetActive(true);
        TimeBarPar.SetActive(true);

        //譜面測試
        BGM.time = st_time;
        passtime = st_time;
        BGM.Play();
        for (int i=0; i<fname.Length; i++)
        {
            if (inv_time[i] >= st_time)
            {
                Invoke(fname[i], inv_time[i] - st_time);
            }
        }

        //Invoke譜面
        //Invoke("Map01", 1.4f);
        //Invoke("Map02", 1.58f);
        //Invoke("Map03", 1.76f);
        //Invoke("Map04", 1.94f);
        //Invoke("Map05", 2.12f);
        //Invoke("Map06",2.3f);
        //Invoke("Map07", 2.48f);
        //Invoke("Map08",2.66f);
        //Invoke("Map09", 2.79f);
        //Invoke("Map10", 2.97f);
        //Invoke("Map11", 3.15f);
        //Invoke("Map12", 3.33f);
        //Invoke("Map13", 3.51f);
        //Invoke("Map14", 3.69f);
        //Invoke("Map15", 3.87f);
        //Invoke("Map16", 4.05f);
        //Invoke("Map17", 4.23f);
        //Invoke("Map18", 4.41f);
        //Invoke("Map19", 4.59f);
        //Invoke("Map20", 4.77f);
        //Invoke("Map21", 4.95f);
        //Invoke("Map22", 5.13f);
        //Invoke("Map23", 5.31f);
        //Invoke("Map24", 5.49f);
        //Invoke("Map25", 5.64f);
        //Invoke("Map26", 5.82f);
        //Invoke("Map27", 6.0f);
        //Invoke("Map28", 6.18f);
        //Invoke("Map29",6.36f);
        //Invoke("Map30",6.54f);
        //Invoke("Map31", 6.72f);
        //Invoke("Map32", 6.77f);
        //Invoke("Map33", 6.8f);
        //Invoke("Map34", 7.28f);
        //Invoke("Map35", 8.33f);
        //Invoke("Map36", 8.73f);
        //Invoke("Map37", 9.1f);
        //Invoke("Map38", 9.6f);
        //Invoke("Map39", 10.1f);
        //Invoke("Map40", 21.4f);
        //Invoke("Map41", 22.9f);
        //Invoke("Map42", 33.5f);
        //Invoke("Map43", 38.33f);
        //Invoke("Map44", 38.58f);
        //Invoke("Map45", 38.83f);
        //Invoke("Map46", 44.3f);

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
    void Map00()
    {
        State[0].SetActive(true);
    }
    void Map01()
    {
        Brick[0].SetActive(true);
    }
    void Map02()
    {
        Brick[1].SetActive(true);
    }
    void Map03()
    {
        Brick[2].SetActive(true);
    }
    void Map04()
    {
        Brick[3].SetActive(true);
    }
    void Map05()
    {
        Brick[4].SetActive(true);
    }
    void Map06()
    {
        Brick[5].SetActive(true);
    }
    void Map07()
    {
        Brick[6].SetActive(true);
    }
    void Map08()
    {
        Brick[7].SetActive(true);
    }
    void Map09()
    {
        Brick[8].SetActive(true);
    }
    void Map10()
    {
        Brick[9].SetActive(true);
    }
    void Map11()
    {
        Brick[10].SetActive(true);
    }
    void Map12()
    {
        Brick[11].SetActive(true);
    }
    void Map13()
    {
        Brick[12].SetActive(true);
    }
    void Map14()
    {
        Brick[13].SetActive(true);
    }
    void Map15()
    {
        Brick[14].SetActive(true);
    }
    void Map16()
    {
        Brick[15].SetActive(true);
    }
    void Map17()
    {
        Brick[16].SetActive(true);
    }
    void Map18()
    {
        Brick[17].SetActive(true);
    }
    void Map19()
    {
        Brick[18].SetActive(true);
    }
    void Map20()
    {
        Brick[19].SetActive(true);
    }
    void Map21()
    {
        Brick[20].SetActive(true);
    }
    void Map22()
    {
        Brick[21].SetActive(true);
    }
    void Map23()
    {
        Brick[22].SetActive(true);
    }
    void Map24()
    {
        Brick[23].SetActive(true);
    }
    void Map25()
    {
        Brick[24].SetActive(true);
    }
    void Map26()
    {
        Brick[25].SetActive(true);
    }
    void Map27()
    {
        Brick[26].SetActive(true);
    }
    void Map28()
    {
        Brick[27].SetActive(true);
    }
    void Map29()
    {
        Brick[28].SetActive(true);
    }
    void Map30()
    {
        Brick[29].SetActive(true);
    }
    void Map31()
    {
        Brick[30].SetActive(true);
    }
    void Map32()
    {
        Brick[31].SetActive(true);
    }
    void Map33()
    {
        Brick[32].SetActive(true);
        Brick[33].SetActive(true);
        Brick[34].SetActive(true);
        Brick[35].SetActive(true);
    }
    void Map34()
    {
        Brick[36].SetActive(true);
        Brick[37].SetActive(true);
    }
    void Map35()
    {
        Brick[38].SetActive(true);
    }
    void Map36()
    {
        Brick[39].SetActive(true);
    }
    void Map37()
    {
        Brick[40].SetActive(true);
    }
    void Map38()
    {
        Brick[41].SetActive(true);
        Brick[42].SetActive(true);
    }
    void Map39()
    {
        Brick[43].SetActive(true);
        Brick[44].SetActive(true);
    }
    void Map40()
    {
        State[0].SetActive(false);
    }
    void Map41()
    {
        State[1].SetActive(true);
    }
    void Map42()
    {
        State[1].SetActive(false);
        State[2].SetActive(true);
    }
    void Map43()
    {
        Brick[45].SetActive(true);
    }
    void Map44()
    {
        Brick[46].SetActive(true);
    }
    void Map45()
    {
        Brick[47].SetActive(true);
    }
    void Map46()
    {
        State[2].SetActive(false);
        State[3].SetActive(true);
    }
    void Map47()
    {
        Effect[0].SetBool("Disapper", true);
        Brick[48].SetActive(false);
        Brick[49].SetActive(false);
        Ball.velocity = Vector3.zero;
        Ball.bodyType = RigidbodyType2D.Kinematic;
        Brick[49].transform.parent = Brick[48].transform;
        Brick[49].transform.localPosition = new Vector3(0f, 0.85f, 2.54f);
    }
    void Map48()
    {
        State[4].SetActive(true);
        Brick[48].transform.position = new Vector2(-0.22f, -12.35f);
        Brick[48].SetActive(true);
        Brick[49].SetActive(true);
    }
    void Map49()
    {
        Brick[49].transform.parent = null;
        Ball.bodyType = RigidbodyType2D.Dynamic;
        transform.SetParent(null);
        Ball.velocity = new Vector2(0, 400);
    }
    void Map50()
    {
        State[4].SetActive(false);
        Brick[48].SetActive(false);
        Brick[49].SetActive(false);

        Ball.velocity = Vector3.zero;
        Ball.bodyType = RigidbodyType2D.Kinematic;
        Brick[49].transform.parent = Brick[48].transform;
        Brick[49].transform.localPosition = new Vector3(0f, 0.85f, 2.54f);
        Brick[48].transform.position = new Vector2(-0.22f, -34.8f);
    }
    void Map51()
    {
        State[5].SetActive(true);
        Brick[48].SetActive(true);
        Brick[49].SetActive(true);
    }
    void Map52()
    {
        State[5].SetActive(false);

        Brick[48].SetActive(false);
        Brick[49].SetActive(false);
        Ball.velocity = Vector3.zero;
        Ball.bodyType = RigidbodyType2D.Kinematic;
        Brick[49].transform.parent = Brick[48].transform;
        Brick[49].transform.localPosition = new Vector3(0f, 0.85f, 2.54f);
        Brick[48].transform.position = new Vector2(-0.22f, -31.9f);
    }
    void Map53()
    {
        State[6].SetActive(true);
        Brick[48].SetActive(true);
        Brick[49].SetActive(true);
    }
    void Map54()
    {
        State[7].SetActive(true);
        State[6].SetActive(false);
    }



}
