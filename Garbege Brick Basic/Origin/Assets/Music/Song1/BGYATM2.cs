using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGYATM2 : MonoBehaviour {
private GameObject bb3;
private GameObject bb2;
private GameObject bb4;
private GameObject Wall;
private GameObject bb5;
private GameObject bb6;
private GameObject bb7;
public List<GameObject> Brick = new List<GameObject>();
    private GameObject R1;
    private GameObject R2;
    private GameObject R3;
    private GameObject R4;
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

    // Use this for initialization
    void Start () {
    Wall = GameObject.FindGameObjectWithTag("EffectWall0");
    bb3 = GameObject.FindGameObjectWithTag("Brick5");
    bb2 = GameObject.FindGameObjectWithTag("Brick4");
    bb4 = GameObject.FindGameObjectWithTag("Brick7");
    bb5 = GameObject.FindGameObjectWithTag("Brick8");
    bb6 = GameObject.FindGameObjectWithTag("Brick9");
    bb7 = GameObject.FindGameObjectWithTag("Brick10");
    R1 = GameObject.FindGameObjectWithTag("EffectBrick1");
    R2 = GameObject.FindGameObjectWithTag("EffectBrick2");
    R3 = GameObject.FindGameObjectWithTag("EffectBrick3");
    R4 = GameObject.FindGameObjectWithTag("EffectBrick4");
        Wall.gameObject.SetActive(false);
        

        IFuckedUp();
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
        Invoke("FollowTheMusic3", 31);
        Invoke("FollowTheMusic2", 28);
        Invoke("FollowTheMusic1", 13.75f);
        Invoke("FollowTheMusic1002", 15.2f);
        Invoke("FollowTheMusic1003", 16.7f);
        Invoke("FollowTheMusic1004", 18.15f);
        InvokeRepeating("FollowTheMusic4", 37, 0.375f);
        InvokeRepeating("FollowTheMusic40", 37.1875f, 0.375f);
        Invoke("FollowTheMusic5", 49);
        Invoke("FollowTheMusic6", 61);
        Invoke("FollowTheMusic7", 72.5f);
        Invoke("FollowTheMusic8", 75.5f);
        Invoke("FollowTheMusic9", 78.5f);
        Invoke("FollowTheMusic10", 81.45f);
        Invoke("Reverse", 95.75f);
        Invoke("Reverse1", 96);
        Invoke("Reverse2", 96.6875f);
        Invoke("Reverse3", 97.5f);
        Invoke("Reverse4", 98.3125f);
        Invoke("Reverse10", 99.0f);
        Invoke("Reverse20", 99.75f);
        Invoke("Reverse30", 100.6125f);
        Invoke("Reverse40", 101.25f);
        Invoke("Reverse5", 102.05f);
        Invoke("Reverse6", 102.75f);
        Invoke("Reverse7", 103.5f);
        Invoke("Reverse8", 104.35f);
        Invoke("Reverse50", 105f);
        Invoke("Reverse60", 105.7f);
        Invoke("Reverse70", 106.5f);
        Invoke("Reverse80", 106.5f);
        Invoke("ReverseEnd", 107);
        Invoke("FollowTheMusic1101", 118.2f);
        Invoke("FollowTheMusic1102", 118.4f);
        Invoke("FollowTheMusic1103", 118.6f);
        Invoke("FollowTheMusic1104", 118.8f);
        Invoke("FollowTheMusic1105", 119f);
        Invoke("FollowTheMusic1106", 119.2f);
        Invoke("FollowTheMusic1107", 119.4f);
        Invoke("FollowTheMusic1201", 130f);
        Invoke("FollowTheMusic1202", 130.2f);
        Invoke("FollowTheMusic1203", 130.4f);
        Invoke("FollowTheMusic1204", 130.6f);
        Invoke("FollowTheMusic1205", 130.8f);
        Invoke("FollowTheMusic1206", 131f);
        Invoke("FollowTheMusic1207", 131.2f);
        Invoke("FollowTheMusic13", 119.75f);
        Invoke("FollowTheMusic14", 122.75f);
        Invoke("FollowTheMusic15", 125.7f);
        Invoke("FollowTheMusic16", 128.6f);
        Invoke("FollowTheMusic17", 131.5f);
        Invoke("FollowTheMusic18", 134.45f);
        Invoke("FollowTheMusic1901", 137.4f);
        Invoke("FollowTheMusic1902", 138.1f);
        Invoke("FollowTheMusic1903", 138.8f);
        Invoke("FollowTheMusic1904", 139.5f);
        Invoke("FollowTheMusic2001", 143.25f);
        Invoke("FollowTheMusic2002", 144.7f);
        Invoke("FollowTheMusic2003", 146.2f);
        Invoke("FollowTheMusic2004", 147.65f);
        Invoke("FollowTheMusic21", 155f);
        Invoke("FollowTheMusic2200", 156.5f);
        Invoke("FollowTheMusic2201", 156.6f);
        Invoke("FollowTheMusic2202", 156.7f);
        Invoke("FollowTheMusic2203", 156.8f);
        Invoke("FollowTheMusic2204", 156.9f);
        Invoke("FollowTheMusic2205", 157f);
        Invoke("FollowTheMusic2206", 157.1f);
        Invoke("FollowTheMusic2207", 157.2f);
        Invoke("FollowTheMusic2208", 157.3f);
        Invoke("FollowTheMusic2209", 157.4f);
        Invoke("FollowTheMusic2210", 157.5f);
        Invoke("FollowTheMusic2211", 157.6f);
        Invoke("FollowTheMusic2212", 157.7f);
        Invoke("FollowTheMusic2213", 157.8f);
        Invoke("FollowTheMusic2214", 157.9f);
        Invoke("FollowTheMusic2215", 158f);
        Invoke("FollowTheMusic2216", 158.1f);

    }

void IFuckedUp()
{

        bb7.gameObject.SetActive(false);
        bb3.gameObject.SetActive(false);
        bb2.gameObject.SetActive(false);
        bb4.gameObject.SetActive(false);
        bb5.gameObject.SetActive(false);
        bb6.gameObject.SetActive(false);
        R1.gameObject.SetActive(false);
        R2.gameObject.SetActive(false);
        R3.gameObject.SetActive(false);
        R4.gameObject.SetActive(false);
    }
void FollowTheMusic1()
{
    Brick[0].SetActive(true);
}
void FollowTheMusic1002()
    {
        Brick[1].SetActive(true);
    }
void FollowTheMusic1003()
    {
        Brick[2].SetActive(true);
    }
void FollowTheMusic1004()
    {
        Brick[3].SetActive(true);
    }
void FollowTheMusic2()
{
    bb2.SetActive(true);
}
void FollowTheMusic3()
{
    bb3.SetActive(true);
}
void FollowTheMusic4()
{
    bb4.SetActive(true);
}
void FollowTheMusic40()
{
    bb4.SetActive(false);
}
void FollowTheMusic5()
{
    bb5.SetActive(true);
}
void FollowTheMusic6()
{
        Destroy(bb4);
    bb6.SetActive(true);
}
void FollowTheMusic7()
{
    Brick[4].SetActive(true);
}
void FollowTheMusic8()
{
    Brick[5].SetActive(true);
}
void FollowTheMusic9()
{
    Brick[6].SetActive(true);
}
void FollowTheMusic10()
{
    Brick[7].SetActive(true);
}
void Reverse()
{
    Wall.SetActive(true);
        Destroy(Brick[0]);
        Destroy(Brick[1]);
        Destroy(Brick[2]);
        Destroy(Brick[3]);
        Destroy(Brick[4]);
        Destroy(Brick[5]);
        Destroy(Brick[6]);
        Destroy(Brick[7]);
        Destroy(bb2);
        Destroy(bb3);
        Destroy(bb5);
        Destroy(bb6); 
    }
void Reverse1()
    {
        R1.SetActive(true);
    }
void Reverse2()
    {
        R2.SetActive(true);
    }
void Reverse3()
    {
        R3.SetActive(true);
    }
void Reverse4()
    {
        R4.SetActive(true);
    }
void Reverse10()
    {
        Destroy(R1);
    }
void Reverse20()
    {
        Destroy(R2);
    }
void Reverse30()
    {
        Destroy(R3);
    }
void Reverse40()
    {
       Destroy(R4);
    }
void Reverse5()
{
    Brick[8].SetActive(true);
}
void Reverse6()
{
    Brick[9].SetActive(true);
}
void Reverse7()
{
    Brick[10].SetActive(true);
}
void Reverse8()
{ 
    Brick[11].SetActive(true);
}
void Reverse50()
{
    Brick[8].SetActive(false);
}
void Reverse60()
{
    Brick[9].SetActive(false);
}
void Reverse70()
{
    Brick[10].SetActive(false);
}
void Reverse80()
{
    Brick[11].SetActive(false);
}
void FollowTheMusic1101()
{
    Brick[12].SetActive(true);
}
void FollowTheMusic1102()
{
        Destroy(Brick[12]);
    Brick[13].SetActive(true);
}
void FollowTheMusic1103()
{
        Destroy(Brick[13]);
        Brick[14].SetActive(true);
}
void FollowTheMusic1104()
{
        Destroy(Brick[14]);
        Brick[15].SetActive(true);
}
void FollowTheMusic1105()
{
        Destroy(Brick[15]);
        Brick[16].SetActive(true);
}
void FollowTheMusic1106()
{
        Destroy(Brick[16]);
        Brick[17].SetActive(true);
}
void FollowTheMusic1107()
{
        Destroy(Brick[17]);
        Destroy(bb7);
        Brick[18].SetActive(true);
}
void FollowTheMusic1201()
{
    Brick[19].SetActive(true);
}
void FollowTheMusic1202()
{
        Destroy(Brick[19]);
    Brick[20].SetActive(true);
}
void FollowTheMusic1203()
{
        Destroy(Brick[20]);
        Brick[21].SetActive(true);
}
void FollowTheMusic1204()
{
        Destroy(Brick[21]);
        Brick[22].SetActive(true);
}
void FollowTheMusic1205()
{
        Destroy(Brick[22]);
        Brick[23].SetActive(true);
}
void FollowTheMusic1206()
{
        Destroy(Brick[23]);
        Brick[24].SetActive(true);
}
void FollowTheMusic1207()
{
        Destroy(Brick[24]);
        Brick[25].SetActive(true);
}
void FollowTheMusic13()
{
    Brick[26].SetActive(true);
}
void FollowTheMusic14()
{
    Brick[27].SetActive(true);
}
void FollowTheMusic15()
{
    Brick[28].SetActive(true);
}
void FollowTheMusic16()
{
    Brick[29].SetActive(true);
}
void FollowTheMusic17()
{
    Brick[30].SetActive(true);
}
void FollowTheMusic18()
{
        Brick[31].SetActive(true);
}
void FollowTheMusic1901()
{
        Brick[32].SetActive(true);
}
void FollowTheMusic1902()
{
        Brick[33].SetActive(true);
}
void FollowTheMusic1903()
{
        Brick[34].SetActive(true);
}
void FollowTheMusic1904()
{
        Brick[35].SetActive(true);
}
void FollowTheMusic2001()
{
    Brick[36].SetActive(true);
}
void FollowTheMusic2002()
{
        Brick[37].SetActive(true);
}
void FollowTheMusic2003()
{
        Brick[38].SetActive(true);
}
void FollowTheMusic2004()
{
        Brick[39].SetActive(true);
}
void FollowTheMusic21()
{
        Destroy(Brick[18]);
        Destroy(Brick[25]);
        Destroy(Brick[26]);
        Destroy(Brick[27]);
        Destroy(Brick[28]);
        Destroy(Brick[29]);
        Destroy(Brick[30]);
        Destroy(Brick[31]);
        Destroy(Brick[32]);
        Destroy(Brick[33]);
        Destroy(Brick[34]);
        Destroy(Brick[35]);
        Destroy(Brick[36]);
        Destroy(Brick[37]);
        Destroy(Brick[38]);
        Destroy(Brick[39]);
}
void FollowTheMusic2200()
    {
        Brick[40].SetActive(true);
    }
void FollowTheMusic2201()
    {
        Brick[41].SetActive(true);
    }
void FollowTheMusic2202()
    {
        Brick[42].SetActive(true);
    }
void FollowTheMusic2203()
    {
        Brick[43].SetActive(true);
    }
void FollowTheMusic2204()
    {
        Brick[44].SetActive(true);
    }
void FollowTheMusic2205()
    {
        Brick[45].SetActive(true);
    }
void FollowTheMusic2206()
    {
        Brick[46].SetActive(true);
    }
void FollowTheMusic2207()
    {
        Brick[47].SetActive(true);
    }
void FollowTheMusic2208()
    {
        Brick[48].SetActive(true);
    }
void FollowTheMusic2209()
    {
        Brick[49].SetActive(true);
    }
void FollowTheMusic2210()
    {
        Brick[50].SetActive(true);
    }
void FollowTheMusic2211()
    {
        Brick[51].SetActive(true);
    }
void FollowTheMusic2212()
    {
        Brick[52].SetActive(true);
    }
void FollowTheMusic2213()
    {
        Brick[53].SetActive(true);
    }
void FollowTheMusic2214()
    {
        Brick[54].SetActive(true);
    }
void FollowTheMusic2215()
    {
        Brick[55].SetActive(true);
    }
void FollowTheMusic2216()
    {
        Destroy(Brick[40]);
        Destroy(Brick[41]);
        Destroy(Brick[42]);
        Destroy(Brick[43]);
        Destroy(Brick[44]);
        Destroy(Brick[45]);
        Destroy(Brick[46]);
        Destroy(Brick[47]);
        Destroy(Brick[48]);
        Destroy(Brick[49]);
        Destroy(Brick[50]);
        Destroy(Brick[51]);
        Destroy(Brick[52]);
        Destroy(Brick[53]);
        Destroy(Brick[54]);
        Destroy(Brick[55]);
        Brick[56].SetActive(true);
    }
    void ReverseEnd()
    {
        Destroy(Wall);
        bb7.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Dead.Fail != true && MusicStart && (songTime - (int)passtime) > 0)
            passtime += Time.deltaTime;
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

}
