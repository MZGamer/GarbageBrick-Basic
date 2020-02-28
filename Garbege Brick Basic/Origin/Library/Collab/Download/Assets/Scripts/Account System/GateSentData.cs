using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Net;

public class GateSentData : MonoBehaviour {
    public PlayerDataList List;
    public UnityWebRequest Upload;
    public bool UploadComplete;
    string saveString;

    // Use this for initialization
    void Start () {
        UploadComplete = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Gate.RegisterComplete&&UploadComplete == false)
        {


            string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "GameData.json");
            List = Gate.ReadyToJason;
            saveString = JsonUtility.ToJson(List);
            if (filePath.Contains("://") || filePath.Contains(":///"))
            {

            StartCoroutine(UploadData());
            }
            else
            {
                List = Gate.ReadyToJason;
                saveString = JsonUtility.ToJson(List);
                Debug.Log(saveString);
                StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.streamingAssetsPath, "GameData.json"));
                file.Write(saveString);
                file.Close();
                Debug.Log("Done");
            }

        }
	}

    IEnumerator UploadData()
    {
        Debug.Log("Start Upload");
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com/");
        request.Method = WebRequestMethods.Ftp.UploadFile;

        request.Credentials = new NetworkCredential("tfcisgamedev", "s10011001");
        byte[] fileContents;
        using (StreamReader sourceStream = new StreamReader("GameData.json"))
        {
            fileContents = System.Text.Encoding.UTF8.GetBytes(saveString);
        }

        request.ContentLength = fileContents.Length;

        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(fileContents, 0, fileContents.Length);
        }
        yield return 0;

        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        {
            Debug.Log("Upload complete!");
            Debug.Log(Gate.ReadyToJason.PlayerDatas.Count);
            UploadComplete = true;
        }



    }


}
