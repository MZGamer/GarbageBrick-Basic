using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeatMap06 : MonoBehaviour {
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


    void Start()
    {
        PlayerPrefs.SetInt("Completed", 0);
        PlayerPrefs.SetInt("isStandBy", 0);
        MusicStart = false;
        Invoke("StandingBy", 2);
        //Invoke("GameStart", 0);
        for (int i = 0; i < fname.Length; i++){
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
        if (Dead.Fail != true && MusicStart && (songTime - (int)passtime)>0)
            passtime += Time.deltaTime;
        //TTime.text = "Time: " + (songTime - (int)passtime);
	TimeBar.transform.position = new Vector3(passtime / songTime*135-135f, -36f, -1);
	TimeBarPar.transform.position = new Vector3(passtime / songTime*135-67f, -36f, -1);
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
    void Drop00()
    {
        State[0].SetActive(true);
    }
    void Drop01()
    {
        State[1].SetActive(true);
    }
    void Drop02()
    {
        State[2].SetActive(true);
    }
    void Drop03()
    {
        State[3].SetActive(true);
    }
    void Drop04()
    {
        State[4].SetActive(true);
    }
    void Drop05()
    {
        State[5].SetActive(true);
    }
    void Drop06()
    {
        State[6].SetActive(true);
    }
    void Drop07()
    {
        State[7].SetActive(true);
    }
    void Drop08()
    {
        State[8].SetActive(true);
    }
    void Drop09()
    {
        State[9].SetActive(true);
    }
    void Drop10()
    {
        State[10].SetActive(true);
    }
    void Drop11()
    {
        State[11].SetActive(true);
    }
    void Drop12()
    {
        State[12].SetActive(true);
    }
    void Drop13()
    {
        State[13].SetActive(true);
    }
    void Drop14()
    {
        State[14].SetActive(true);
    }
    void Drop15()
    {
        State[15].SetActive(true);
    }
    void Drop16_clear()
    {
        for (int i = 0; i < 15; i++){
            State[i].SetActive(false);
        }
        State[16].SetActive(true);
    }
    void Drop17_clear()
    {
        State[16].SetActive(false);
        State[17].SetActive(true);
    }
    void Drop18()
    {
        State[18].SetActive(true);
    }
    void Drop19_clear(){
        State[17].SetActive(false);
        State[18].SetActive(false);
        State[19].SetActive(true);
    }
    void Drop20(){
        State[19].SetActive(false);
        State[20].SetActive(true);
    }
    void Drop21(){
        State[21].SetActive(true);
    }
    void Drop22(){
        State[22].SetActive(true);
    }
    void Drop23(){
        State[23].SetActive(true);
    }
    void Drop24(){
        State[24].SetActive(true);
    }
    void Drop25(){
        State[25].SetActive(true);
    }
    void Drop26_clear(){
        State[24].SetActive(false);
        State[25].SetActive(false);
        State[26].SetActive(true);
    }
    void Drop27(){
        State[27].SetActive(true);
    }
    void Drop28(){
        State[28].SetActive(true);
    }
    void Drop29(){
        State[29].SetActive(true);
    }
    void Drop30(){
        State[30].SetActive(true);
    }
    void Drop31(){
        State[31].SetActive(true);
    }
}
