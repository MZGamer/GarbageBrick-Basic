using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GetPlayerData : MonoBehaviour {
    public PlayerDataList Data;
    static public List<PlayerData> JasonplayerDatas = new List<PlayerData>();
    static public bool DataGet;



    // Use this for initialization
    void Start () {
        DataGet = false;

        StreamReader file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "GameData.json"));
        string JasonData = file.ReadToEnd();
        file.Close();
        Data = JsonUtility.FromJson<PlayerDataList>(JasonData);
        JasonplayerDatas = Data.PlayerDatas;
        DataGet = true;

    }
	
	// Update is called once per frame
	void Update () {
    }
}
