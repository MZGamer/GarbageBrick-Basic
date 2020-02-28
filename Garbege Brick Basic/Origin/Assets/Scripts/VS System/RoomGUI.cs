using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomGUI : MonoBehaviour {
    [Header("HostData")]
    public Text HName;
    public Text HLV;
    public Text HCatch;
    public Text HBall;
    public GameObject HReady;

    [Header("GuestData")]
    public Text GName;
    public Text GLV;
    public Text GCatch;
    public Text GBall;
    public GameObject GReady;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (VSManager.HName != "")
        {
            HName.text = VSManager.HName;
            HLV.text = "LV:" + VSManager.HLV.ToString();
            HCatch.text = "Catcher:" + VSManager.HCatch.ToString();
            HBall.text = "Ball:" + VSManager.HBall.ToString();
        }

        if (VSManager.GName != "")
        {
            GName.text = VSManager.GName;
            GLV.text = "LV:" + VSManager.GLV.ToString();
            GCatch.text = "Catcher:" + VSManager.GCatch.ToString();
            GBall.text = "Ball:" + VSManager.GBall.ToString();
        }
        if (VSManager.HReady)
        {
            HReady.SetActive(true);
        }
        if (VSManager.GReady)
        {
            GReady.SetActive(true);
        }
    }


    public void Ready()
    {
        if (VSManager.Guest)
        {
            VSManager.GReady = true;
        }
        else
        {
            VSManager.HReady = true;
        }

    }

}
