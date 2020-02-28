using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Highscore", Result.HighScore);
        PlayerPrefs.SetInt("PassLevel", Result.passlevel);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
