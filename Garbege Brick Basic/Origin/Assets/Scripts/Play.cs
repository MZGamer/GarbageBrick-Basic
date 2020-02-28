using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour {

    // Use this for initialization
    public GameObject canvas;
    void Start()
    {
        //按下按鈕後，呼叫ClickEvent()
        GetComponent<Button>().onClick.AddListener(() => {
            ClickEvent();
        });
    }

    void ClickEvent()
    {
        //刪掉canvas
        Destroy(canvas);
    }
}
