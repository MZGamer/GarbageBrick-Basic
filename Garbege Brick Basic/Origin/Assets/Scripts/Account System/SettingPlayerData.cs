using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SettingPlayerData : MonoBehaviour {
    public PlayerDataList List;

    // Use this for initialization
    void Start () {
        List = Shop.Data;
    }
	
	// Update is called once per frame
	void Update () {

        if (Shop.SetComplete && Gate.Online == false)
        {
            List = Shop.Data;
            string saveString = JsonUtility.ToJson(List);
            Debug.Log("complete");
            Debug.Log(saveString);
            StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.streamingAssetsPath, "GameData.json"));
            file.Write(saveString);
            file.Close();
            Debug.Log("complete");
            Shop.SetComplete = false;
        }

        Debug.Log(Shop.SetComplete);

    }
}
