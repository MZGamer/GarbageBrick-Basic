using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewSongSlect : MonoBehaviour {
    public List<SongData> SongData = new List<SongData>();
    static public List<SongData> SongDataBK = new List<SongData>();
    public Image Background;
    public Text Author, SongName;
    public GameObject Gamestart,ShopButtom,BlackMask;

    public Image Catcher, Ball;
    public ItemIDCreator ItemList;

    public AudioClip BGM;
    public AudioSource Sound;
    public string beatmap;
    static public int ID = 1;
    public Animator SongSlectAni;

    [Header("Loading")]
    public static bool Standby;
    public bool PressLeft = false;
    public bool PressRight = false;
    public GameObject Information;
    public Text InfSongName;
    public Text InfAuthor;
    public Image InfSBG;
    public GameObject Canves;

    [Header("TrackCount")]
    public Text TrackCount;
    public int MaxTrack;
    public static int MaxTrackCheck;
    public static int TrackNo = 1;


    public List<Animation> Fade = new List<Animation>();
    // Use this for initialization
    void Start () {
        Invoke("BlackMaskBye", 1);
        Standby = false;
        if (TrackNo > MaxTrack)
        {
            ID = 1;
            TrackNo = 1;
        }

        Background.sprite = SongData[ID - 1].image;
        BGM = SongData[ID - 1].music;
        Author.text = SongData[ID - 1].Author;
        beatmap = SongData[ID - 1].beatmapName;
        Sound.clip = BGM;
        SongName.text = SongData[ID - 1].SongName;
        Sound.Play();
        SongDataBK = SongData;

        if (Gate.Login)
        {
            Ball.sprite = ItemList.ItemList[Gate.NowAccount.BallSet].Image;
            Catcher.sprite = ItemList.ItemList[Gate.NowAccount.CatcherSet].Image;
        }
        if (Gate.Online&&Gate.Login&&Gate.Arcade!= true)
        {
            ShopButtom.SetActive(true);
        }



        InfAuthor.text = SongData[ID - 1].Author;
        InfSongName.text = SongData[ID - 1].SongName;
        InfSBG.sprite = SongData[ID - 1].image;

        MaxTrackCheck = MaxTrack;
        if(Gate.Online && Gate.Arcade!= true)
            TrackCount.text = "SongSlect";
        else
            TrackCount.text = "Track " + TrackNo;
    }
	
	// Update is called once per frame
	void Update () {
        if (Gate.Login)
        {
            Ball.sprite = ItemList.ItemList[Gate.NowAccount.BallSet].Image;
            Catcher.sprite = ItemList.ItemList[Gate.NowAccount.CatcherSet].Image;
        }
        IDchange();
        pressstart();

    }
    void IDchange()
    {
        if (Standby != true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)&&SlectSetting.Setting!=true)
            {
                if (ID + 1 > SongData.Count)
                {
                    ID = 1;
                    Songchange();
                }
                else
                {
                    ID++;
                    Songchange();
                }

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && SlectSetting.Setting != true)
            {
                if (ID - 1 <= 0)
                {
                    ID = SongData.Count;
                    Songchange();
                }
                else
                {
                    ID--;
                    Songchange();
                }
            }
            
        }
    }

    void Songchange()
    {
        Background.sprite = SongData[ID - 1].image;
        BGM = SongData[ID - 1].music;
        Author.text = SongData[ID - 1].Author;
        beatmap = SongData[ID - 1].beatmapName;
        Sound.clip = BGM;
        SongName.text = SongData[ID - 1].SongName;
        Sound.Play();

        InfAuthor.text = SongData[ID - 1].Author;
        InfSongName.text = SongData[ID - 1].SongName;
        InfSBG.sprite = SongData[ID - 1].image;

    }
    public void pressstart()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&SlectSetting.Setting!=true)
            StartGame();
    }
    public void StartGame()
    {
        Standby = true;
        SongSlectAni.SetBool("StandBy", true);
        Invoke("ChangeInf", 2.5f);
    }
    void ChangeInf()
    {
        Information.SetActive(true);
        Invoke("Changescene", 5f);
    }
    void Changescene()
    {
        DontDestroyOnLoad(Canves.transform);
        SceneManager.LoadScene(beatmap);
    }

    public void Gotoshop()
    {
        SongSlectAni.Play("GoToShop");
        Invoke("LoadShop", 1.5f);
    }
    void LoadShop()
    {
        SceneManager.LoadScene("OnlineShop");
    }
    void BlackMaskBye()
    {
        BlackMask.SetActive(false);
    }
}
