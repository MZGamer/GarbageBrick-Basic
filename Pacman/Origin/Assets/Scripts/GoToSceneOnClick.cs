using UnityEngine;

using System.Collections;

using UnityEngine.UI; //Button

using UnityEngine.SceneManagement; //SceneManager



public class GoToSceneOnClick : MonoBehaviour

{

    public int sceneIndex; //要載入的Scene



    void Start()

    {
        //為按鈕加入On Click事件

        GetComponent<Button>().onClick.AddListener(() => {
            ClickEvent();

        });

    }

    private void Update()
    {
    }



    void ClickEvent()

    {
        if(Pacrespawn.level != 1)
        {
            Pacrespawn.level = 1;
        }
        ScoreMan.usetime = 0;

    }
}