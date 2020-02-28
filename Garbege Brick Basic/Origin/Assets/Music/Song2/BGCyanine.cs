using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGCyanine : MonoBehaviour {
    private GameObject br1;
    private GameObject br2;
    private GameObject br3;
    private GameObject br4;
    private GameObject br5;
    public List<GameObject> Brick = new List<GameObject>();
    public List<GameObject> EWall = new List<GameObject>();
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
    [Header("譜面相關")]
    public float st_time = 5f;
    public float[] inv_time = {25.4f, 25.5f, 42f, 50.45f, 51.05f, 51.55f, 52.95f, 53.25f, 53.75f, 54.25f, 55.5f, 55.85f, 56.35f, 56.85f, 57.8f, 58.45f, 58.95f, 59.45f, 59.75f, 60.15f, 60.45f, 60.75f,
    71f, 71.65f, 74.35f, 77.05f, 79.75f, 81.3f, 81.45f, 81.6f, 81.75f, 81.9f, 82.05f, 82.2f, 84.85f, 87.5f, 88.75f, 89.4f, 90.05f, 92.65f, 95,
    95.4f, 96.1f, 96.55f, 97.05f, 97.45f, 970f, 970f,
    98f, 98.7f, 99.15f, 99.6f, 100.15f, 1000f, 1000.2f};
    public string[] fname = {"FollowTheMusic2", "FollowTheMusic3", "FollowTheMusic4", "FollowTheMusic5", "FollowTheMusic6", "FollowTheMusic7", "FollowTheMusic8", "FollowTheMusic9", "FollowTheMusic10", 
        "FollowTheMusic11", "FollowTheMusic12", "FollowTheMusic13", "FollowTheMusic14", "FollowTheMusic15", "FollowTheMusic16", "FollowTheMusic17", "FollowTheMusic18", "FollowTheMusic19", 
        "FollowTheMusic2001", "FollowTheMusic2002", "FollowTheMusic2003", "FollowTheMusic2004", "FollowTheMusic21", "FollowTheMusic22", "FollowTheMusic2202", "FollowTheMusic2203", 
        "FollowTheMusic2204", "FollowTheMusic2301", "FollowTheMusic2302", "FollowTheMusic2303", "FollowTheMusic2304", "FollowTheMusic2305", "FollowTheMusic2306", "FollowTheMusic2307", 
        "FollowTheMusic2308", "FollowTheMusic2309", "FollowTheMusic2310", "FollowTheMusic2311", "FollowTheMusic2312", "FollowTheMusic2313", "SpeedUp", "FollowTheMusic2401", "FollowTheMusic2402",
        "FollowTheMusic2403", "FollowTheMusic2404", "FollowTheMusic2405", "FollowTheMusic2406", "FollowTheMusic2407", "FollowTheMusic2408", "FollowTheMusic2409", "FollowTheMusic2410", 
        "FollowTheMusic2411", "FollowTheMusic2412", "FollowTheMusic2413", "FollowTheMusic2414"};


    void Start () {
        PlayerPrefs.SetInt("Completed", 0);
        PlayerPrefs.SetInt("isStandBy", 0);
        MusicStart = false;
        Invoke("StandingBy", 2);
        br1 = GameObject.FindGameObjectWithTag("Brick4");
        br2 = GameObject.FindGameObjectWithTag("Brick5");
        br3 = GameObject.FindGameObjectWithTag("Brick6");
        br4 = GameObject.FindGameObjectWithTag("Brick7");
        br5 = GameObject.FindGameObjectWithTag("Brick8");
        Hidden();


    }
    void StandingBy()
    {
        StandBy.SetActive(true);
        Invoke("SStart", 3);
    }
    void SStart()
    {
        PlayerPrefs.SetInt("isStandBy", 1);
        MusicStart = true;
        Destroy(GameObject.FindGameObjectWithTag("SongSlect"));
        passtime = 0;
        
        //test 
        BGM.time = st_time;
        passtime = st_time;
        BGM.Play();
        TimeBar.SetActive(true);
        TimeBarPar.SetActive(true);
        for (int i = 0; i < fname.Length; i++)
        {
            if (inv_time[i] >= st_time)
            {
                Invoke(fname[i], inv_time[i] - st_time);
            }
        }

        //從Update移來的
        InvokeRepeating("FollowTheMusic1", 10.3f, 0.75f);
        InvokeRepeating("FollowTheMusic1005", 10.675f, 0.75f);
        
        
        //Invoke("FollowTheMusic2", 25.4f);
        //Invoke("FollowTheMusic3", 25.5f);
        //Invoke("FollowTheMusic4", 42f);
        //Invoke("FollowTheMusic5", 50.45f);
        //Invoke("FollowTheMusic6", 51.05f);
        //Invoke("FollowTheMusic7", 51.55f);
        //Invoke("FollowTheMusic8", 52.95f);
        //Invoke("FollowTheMusic9", 53.25f);
        //Invoke("FollowTheMusic10", 53.75f);
        //Invoke("FollowTheMusic11", 54.25f);
        //Invoke("FollowTheMusic12", 55.5f);
        //Invoke("FollowTheMusic13", 55.85f);
        //Invoke("FollowTheMusic14", 56.35f);
        //Invoke("FollowTheMusic15", 56.85f);
        //Invoke("FollowTheMusic16", 57.8f);
        //Invoke("FollowTheMusic17", 58.45f);
        //Invoke("FollowTheMusic18", 58.95f);
        //Invoke("FollowTheMusic19", 59.45f);
        //Invoke("FollowTheMusic2001", 59.75f);
        //Invoke("FollowTheMusic2002", 60.15f);
        //Invoke("FollowTheMusic2003", 60.45f);
        //Invoke("FollowTheMusic2004", 60.75f);
        //Invoke("FollowTheMusic21", 71f);
        //Invoke("FollowTheMusic22", 71.65f);
        //Invoke("FollowTheMusic2202", 74.35f);
        //Invoke("FollowTheMusic2203", 77.05f);
        //Invoke("FollowTheMusic2204", 79.75f);
        //Invoke("FollowTheMusic2301", 81.3f);
        //Invoke("FollowTheMusic2302", 81.45f);
        //Invoke("FollowTheMusic2303", 81.6f);
        //Invoke("FollowTheMusic2304", 81.75f);
        //Invoke("FollowTheMusic2305", 81.9f);
        //Invoke("FollowTheMusic2306", 82.05f);
        //Invoke("FollowTheMusic2307", 82.2f);
        //Invoke("FollowTheMusic2308", 84.85f);
        //Invoke("FollowTheMusic2309", 87.5f);
        //Invoke("FollowTheMusic2310", 88.75f);
        //Invoke("FollowTheMusic2311", 89.4f);
        //Invoke("FollowTheMusic2312", 90.05f);
        //Invoke("FollowTheMusic2313", 92.65f);
        //Invoke("SpeedUp", 95);
        //Invoke("FollowTheMusic2401", 95.4f);
        //Invoke("FollowTheMusic2402", 96f);
        //Invoke("FollowTheMusic2403", 96.5f);
        //Invoke("FollowTheMusic2404", 97f);
        //Invoke("FollowTheMusic2405", 97.15f);
        //Invoke("FollowTheMusic2406", 97.225f);
        //Invoke("FollowTheMusic2407", 97.3f);
        //Invoke("FollowTheMusic2408", 97.8f);
        //Invoke("FollowTheMusic2409", 98.4f);
        //Invoke("FollowTheMusic2410", 98.9f);
        //Invoke("FollowTheMusic2411", 99.4f);
        //Invoke("FollowTheMusic2412", 99.55f);
        //Invoke("FollowTheMusic2413", 99.7f);
        //Invoke("FollowTheMusic2414", 100.2f);
        //Invoke("SpeedUp", 105.75f);
        //Invoke("SpeedUp", 127);
    }
    void Hidden()
    {
        br1.SetActive(false);
        br2.SetActive(false);
        br3.SetActive(false);
        br4.SetActive(false);
        br5.SetActive(false);
    }
    void FollowTheMusic1()
    {
        br1.SetActive(true);
    }
    void FollowTheMusic1005()
    {
        br1.SetActive(false);
    }
    void FollowTheMusic2()
    {
        br3.SetActive(true);
    }
    void FollowTheMusic3()
    {
        br4.SetActive(true);
    }
    void SpeedUp()
    {
        Destroy(EWall[1]);
        EWall[0].SetActive(false);
        EWall[2].SetActive(true);
        Destroy(Brick[19]);
        Destroy(Brick[20]);
        Destroy(Brick[21]);
        Destroy(Brick[22]);
        Destroy(Brick[31]);
        Destroy(Brick[32]);
    }
    void FollowTheMusic4()
    {
        br5.SetActive(true);
    }
    void FollowTheMusic5()
    {
        Destroy(br1);
        Destroy(br3);
        Destroy(br4);
        Brick[0].SetActive(true);
    }
    void FollowTheMusic6()
    {
        Brick[1].SetActive(true);
    }
    void FollowTheMusic7()
    {
        Brick[2].SetActive(true);
    }
    void FollowTheMusic8()
    {
        Brick[3].SetActive(true);
    }
    void FollowTheMusic9()
    {
        Brick[4].SetActive(true);
    }
    void FollowTheMusic10()
    {
        Brick[5].SetActive(true);
    }
    void FollowTheMusic11()
    {
        Brick[6].SetActive(true);
    }
    void FollowTheMusic12()
    {
        Brick[10].SetActive(true);
    }
    void FollowTheMusic13()
    {
        Brick[7].SetActive(true);
    }
    void FollowTheMusic14()
    {
        Brick[8].SetActive(true);
    }
    void FollowTheMusic15()
    {
        Brick[9].SetActive(true);
    }
    void FollowTheMusic16()
    {
        Brick[11].SetActive(true);
    }
    void FollowTheMusic17()
    {
        Brick[12].SetActive(true);
    }
    void FollowTheMusic18()
    {
        Brick[13].SetActive(true);
    }
    void FollowTheMusic19()
    {
        Brick[14].SetActive(true);
    }
    void FollowTheMusic2001()
    {
        Brick[15].SetActive(true);
    }
    void FollowTheMusic2002()
    {
        Brick[16].SetActive(true);
    }
    void FollowTheMusic2003()
    {
        Brick[17].SetActive(true);
    }
    void FollowTheMusic2004()
    {
        Brick[18].SetActive(true);
    }
    void FollowTheMusic21()
    {
        Destroy(br5);
        Destroy(Brick[0]);
        Destroy(Brick[1]);
        Destroy(Brick[2]);
        Destroy(Brick[3]);
        Destroy(Brick[4]);
        Destroy(Brick[5]);
        Destroy(Brick[6]);
        Destroy(Brick[7]);
        Destroy(Brick[8]);
        Destroy(Brick[9]);
        Destroy(Brick[10]);
        Destroy(Brick[11]);
        Destroy(Brick[12]);
        Destroy(Brick[13]);
        Destroy(Brick[14]);
        Destroy(Brick[15]);
        Destroy(Brick[16]);
        Destroy(Brick[17]);
        Destroy(Brick[18]);
    }
    void FollowTheMusic22()
    {
        Brick[19].SetActive(true);
    }
    void FollowTheMusic2202()
    {
        Brick[20].SetActive(true);
    }
    void FollowTheMusic2203()
    {
        Brick[21].SetActive(true);
    }
    void FollowTheMusic2204()
    {
        Brick[22].SetActive(true);
    }
    void FollowTheMusic2301()
    {
        Brick[23].SetActive(true);
    }
    void FollowTheMusic2302()
    {
        Destroy(Brick[23]);
        Brick[24].SetActive(true);
    }
    void FollowTheMusic2303()
    {
        Destroy(Brick[24]);
        Brick[25].SetActive(true);
    }
    void FollowTheMusic2304()
    {
        Destroy(Brick[25]);
        Brick[26].SetActive(true);
    }
    void FollowTheMusic2305()
    {
        Destroy(Brick[26]);
        Brick[27].SetActive(true);
    }
    void FollowTheMusic2306()
    {
        Destroy(Brick[27]);
        Brick[28].SetActive(true);
    }
    void FollowTheMusic2307()
    {
        Destroy(Brick[28]);
        Brick[29].SetActive(true);
    }
    void FollowTheMusic2308()
    {
        Brick[30].SetActive(true);
    }
    void FollowTheMusic2309()
    {
        Destroy(Brick[29]);
        Destroy(Brick[30]);
    }
    void FollowTheMusic2310()
    {
        Brick[31].SetActive(true);
    }
    void FollowTheMusic2311()
    {
        Brick[32].SetActive(true);
    }
    void FollowTheMusic2312()
    {
        Brick[33].SetActive(true);
    }
    void FollowTheMusic2313()
    {
        Destroy(Brick[33]);
    }
    void FollowTheMusic2401()
    {
        Brick[34].SetActive(true);
    }
    void FollowTheMusic2402()
    {
        Destroy(Brick[34]);
        Brick[35].SetActive(true);
    }
    void FollowTheMusic2403()
    {
        Brick[36].SetActive(true);
    }
    void FollowTheMusic2404()
    {
        Brick[37].SetActive(true);
    }
    void FollowTheMusic2405()
    {
        Brick[38].SetActive(true);
    }
    void FollowTheMusic2406()
    {
        Brick[39].SetActive(true);
    }
    void FollowTheMusic2407()
    {
        Brick[40].SetActive(true);
    }
    void FollowTheMusic2408()
    {
        Brick[41].SetActive(true);
    }
    void FollowTheMusic2409()
    {
        Destroy(Brick[41]);
        Brick[42].SetActive(true);
    }
    void FollowTheMusic2410()
    {
        Brick[43].SetActive(true);
    }
    void FollowTheMusic2411()
    {
        Brick[44].SetActive(true);
    }
    void FollowTheMusic2412()
    {
        Brick[45].SetActive(true);
    }
    void FollowTheMusic2413()
    {
        Brick[46].SetActive(true);
    }
    void FollowTheMusic2414()
    {
        Brick[47].SetActive(true);
    }
    void FollowTheMusic2415()
    {
        Brick[48].SetActive(true);
    }
    void FollowTheMusic2416()
    {
        Brick[49].SetActive(true);
    }
    void FollowTheMusic2417()
    {
        Brick[50].SetActive(true);
    }
    void FollowTheMusic2418()
    {
        Brick[51].SetActive(true);
    }
    void FollowTheMusic2419()
    {
        Brick[52].SetActive(true);
    }
    void FollowTheMusic2420()
    {
        Brick[53].SetActive(true);
    }
    void FollowTheMusic2421()
    {
        Brick[54].SetActive(true);
    }
    void FollowTheMusic2422()
    {
        Destroy(Brick[34]);
        Destroy(Brick[35]);
        Destroy(Brick[36]);
        Destroy(Brick[37]);
        Destroy(Brick[38]);
        Destroy(Brick[42]);
        Destroy(Brick[43]);
        Destroy(Brick[44]);
        Destroy(Brick[45]);
        Destroy(Brick[46]);
        Destroy(Brick[47]);
        Destroy(Brick[52]);
        Destroy(Brick[53]);
        Destroy(Brick[54]);

    }
    void FollowTheMusic2501()
    {
        Brick[55].SetActive(true);
    }
    void FollowTheMusic2502()
    {
        Destroy(Brick[55]);
        Brick[58].SetActive(true);
    }
    void FollowTheMusic2503()
    {
        Brick[59].SetActive(true);
    }
    void FollowTheMusic2504()
    {
        Brick[60].SetActive(true);
    }
    void FollowTheMusic2505()
    {
        Brick[61].SetActive(true);
    }
    void FollowTheMusic2506()
    {
        Brick[56].SetActive(true);
        Brick[57].SetActive(true);
    }
    void FollowTheMusic2507()
    {
        Destroy(Brick[56]);
        Destroy(Brick[57]);
        Brick[62].SetActive(true);
    }
    void FollowTheMusic2508()
    {
        Brick[63].SetActive(true);
    }
    void FollowTheMusic2509()
    {
        Brick[64].SetActive(true);
    }
    void FollowTheMusic2510()
    {
        Brick[65].SetActive(true);
    }
    void FollowTheMusic2511()
    {
        EWall[3].SetActive(true);
    }
    void FollowTheMusic2512()
    {
        Brick[66].SetActive(true);
    }
    void FollowTheMusic2513()
    {
        Destroy(Brick[66]);
    }
    void FollowTheMusic2514()
    {
        Brick[67].SetActive(true);
    }
    void FollowTheMusic2515()
    {
        Brick[68].SetActive(true);
    }
    void FollowTheMusic2516()
    {
        Destroy(Brick[39]);
        Destroy(Brick[40]);
        Destroy(Brick[41]);
        Destroy(Brick[48]);
        Destroy(Brick[49]);
        Destroy(Brick[50]);
        Destroy(Brick[51]);
        Destroy(Brick[58]);
        Destroy(Brick[59]);
        Destroy(Brick[60]);
        Destroy(Brick[61]);
        Destroy(Brick[62]);
        Destroy(Brick[63]);
        Destroy(Brick[64]);
        Destroy(Brick[65]);
        Destroy(Brick[67]);
        Destroy(Brick[68]);
        Destroy(EWall[3]);
        Brick[69].SetActive(true);
    }
    void FollowTheMusic2517()
    {
        Brick[70].SetActive(true);
    }
    void FollowTheMusic2518()
    {
        Brick[71].SetActive(true);
    }
    void FollowTheMusic2519()
    {
        Brick[72].SetActive(true);
    }
    void FollowTheMusic2520()
    {
        Brick[73].SetActive(true);
    }
    void FollowTheMusic2521()
    {
        Destroy(Brick[69]);
        Destroy(Brick[70]);
        Destroy(Brick[71]);
        Destroy(Brick[72]);
        Destroy(Brick[73]);
        Ball.velocity = new Vector2(0, 0);
        EWall[2].SetActive(false);
    }
    void FollowTheMusic2601()
    {
        EWall[7].SetActive(true);
        EWall[4].SetActive(true);
        Ball.velocity = new Vector2(25, 25);
        Ball.bodyType = RigidbodyType2D.Dynamic;
        Brick[74].SetActive(true);
        Brick[75].SetActive(true);
        Brick[76].SetActive(true);
        Brick[77].SetActive(true);
        Brick[78].SetActive(true);
        Brick[79].SetActive(true);

    }
    void FollowTheMusic2602()
    {
        Destroy(Brick[74]);
        Destroy(Brick[75]);
        Destroy(Brick[76]);
        Destroy(Brick[77]);
        Destroy(Brick[78]);
        Destroy(Brick[79]);
        Ball.velocity = new Vector2(0, 0);
    }
    void FollowTheMusic2603()
    {
        Ball.velocity = new Vector2(25, 25);
        Ball.bodyType = RigidbodyType2D.Dynamic;
        Brick[80].SetActive(true);
        Brick[81].SetActive(true);
        Brick[82].SetActive(true);
        Brick[83].SetActive(true);
        Brick[84].SetActive(true);
        Brick[85].SetActive(true);

    }
    void FollowTheMusic2604()
    {
        Destroy(Brick[80]);
        Destroy(Brick[81]);
        Destroy(Brick[82]);
        Destroy(Brick[83]);
        Destroy(Brick[84]);
        Destroy(Brick[85]);
        EWall[4].SetActive(false);
        EWall[7].SetActive(false);
        Ball.velocity = new Vector2(0, 0);
    }
    void FollowTheMusic2605()
    {
        EWall[8].SetActive(true);
    }
    void FollowTheMusic2606()
    {
        EWall[8].SetActive(false);
    }

    void Update()
    {
        if (Dead.Fail != true && MusicStart && (songTime - (int)passtime) > 0)
            passtime += Time.deltaTime;
        TimeBar.transform.position = new Vector3(passtime / songTime * 135 - 160.5f, -78.48f, -10);
        TimeBarPar.transform.position = new Vector3(passtime / songTime * 135 - 93.57f, -78.48f, -10);
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
}
