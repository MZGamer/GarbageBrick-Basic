using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour {
    [Header("放自己")]
    public BoxCollider2D dead;
    public static bool Fail = false;
    [Header("放入TrackFail , Loading")]
    public GameObject FailAni;
    public GameObject Loading;
    [Header("放入音樂播放器 , TrackFail")]
    public AudioSource SongBGM;
    [Header("放球和Catcher")]
    public Rigidbody2D ball;
    public GameObject TheBall;
    public GameObject player;
	// Use this for initialization
	void Start () {
        dead = GetComponent<BoxCollider2D>();
        Fail = false;
    
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if(Ball.Life != 1)
            {
                Ball.Life--;
                ball.velocity = Vector3.zero;
                ball.bodyType = RigidbodyType2D.Kinematic;
                TheBall.transform.parent = player.transform;
                TheBall.transform.localPosition = new Vector3(-0.08056901f, 0.85f, 2.54f);
            }
            else
            {
                Ball.Life--;
                Fail = true;
                Destroy(other);
                SongBGM.Pause();
                PlayFailAnimation();
            }

        }
    }
    void Update () {
		
	}
    void PlayFailAnimation()
    {
        FailAni.SetActive(true);
        Invoke("FailAniFinish" , 6.5f);
    }
    void FailAniFinish()
    {
        Loading.SetActive(true);
        Invoke("GotoResult",2f);
    }
    void GotoResult()
    {
        if (!VSManager.Battling)
        {
            if (Gate.Online && Gate.Arcade != true)
                SceneManager.LoadScene("OnlineEnd");
            else
                SceneManager.LoadScene("End");
        }

    }
}
