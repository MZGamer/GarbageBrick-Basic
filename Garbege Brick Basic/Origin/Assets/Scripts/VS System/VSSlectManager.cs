using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class VSSlectManager : MonoBehaviour {
    public SongListCreator SongList;
    public List<SongData> SongData = new List<SongData>();
    static public List<SongData> SongDataBK = new List<SongData>();
    public Image Background;
    public Text Author, SongName;

    public AudioClip BGM;
    public AudioSource Sound;
    public string beatmap;
    static public int ID = 1;
    public static int Round;
    public static bool CanSlect,GameStart;

    public bool Standby;

    public NetworkManager Match;
    public GameObject Network;
    [Header("HostData")]
    public Text HName;
    public Text HLV;
    public Text HCatch;
    public Text HBall;
    public Text HWin;
    public GameObject HStandBy;

    [Header("GuestData")]
    public Text GName;
    public Text GLV;
    public Text GCatch;
    public Text GBall;
    public Text GWin;
    public GameObject GStandBy;


    // Use this for initialization
    void Start () {
        Network = GameObject.FindGameObjectWithTag("NetworkLinker");
        Match = Network.GetComponent<NetworkManager>();

        GameStart = false;
        SongData = SongList.SongData;
        SongDataBK = SongData;

        Background.sprite = SongData[ID - 1].image;
        BGM = SongData[ID - 1].music;
        Author.text = SongData[ID - 1].Author;
        beatmap = SongData[ID - 1].beatmapName;
        Sound.clip = BGM;
        SongName.text = SongData[ID - 1].SongName;
        Sound.Play();

            HName.text = VSManager.HName;
            HLV.text = "LV:" + VSManager.HLV.ToString();
            HCatch.text = "Catcher:" + VSManager.HCatch.ToString();
            HBall.text = "Ball:" + VSManager.HBall.ToString();
            HWin.text = "" + VSManager.HWin;


            GName.text = VSManager.GName;
            GLV.text = "LV:" + VSManager.GLV.ToString();
            GCatch.text = "Catcher:" + VSManager.GCatch.ToString();
            GBall.text = "Ball:" + VSManager.GBall.ToString();
            GWin.text = "" + VSManager.GWin;
    }
	
	// Update is called once per frame
	void Update () {
        if(Round == 3)
        {
            return;
        }
        else if(CanSlect)
        {
            IDchange();
        }
        else
        {
            ID = VSManager.nowID;
            Songchange();
        }
        if (VSManager.GReady)
            GStandBy.SetActive(true);
        else
            GStandBy.SetActive(false);


        if (VSManager.HReady)
            HStandBy.SetActive(true);
        else
            HStandBy.SetActive(false);

        if (GameStart)
        {
            GameStart = false;
            Standby = true;
            
        }
    }

    public void Ready()
    {
        if (VSManager.Guest)
        {
            VSManager.GReady = true;
            GStandBy.SetActive(true);

        }
        else
        {
            VSManager.HReady = true;
            HStandBy.SetActive(true);

        }



    }

    void IDchange()
    {
        if (Standby != true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && SlectSetting.Setting != true)
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
    }
}
