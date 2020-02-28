using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    public GameObject TheBall,player,BattleScore;
    public SpriteRenderer BallSp, playersp;
    Rigidbody2D ball;
    public float speedX;
    public float speedY;
    public Text SelfscoreText;
    public Text BattleScoreText;
    public Text LifeText;
    CircleCollider2D ballCollider2D;
    public int score;
    public static int Life;
    public static int Score;
    private int isstandby;
   
   


    void Start () {
        if (Gate.Login)
        {
            BallSp.sprite = ItemID.ItemList[Gate.NowAccount.BallSet];
            playersp.sprite = ItemID.ItemList[Gate.NowAccount.CatcherSet];
            Life = ItemID.ItemObject[Gate.NowAccount.BallSet].Life;
        }
        else
        {
            Life = 3;
        }
        ball = GetComponent<Rigidbody2D>();

        Score = 0;
        score = 0;
        SelfscoreText.text = "00000";
        ballCollider2D = GetComponent<CircleCollider2D>();
        if (VSManager.Battling)
        {
            BattleScore.SetActive(true);
            if (VSManager.Host)
            {
                BattleScoreText.text = VSManager.GScore.ToString();
            }
            else if(VSManager.Guest){
                BattleScoreText.text = VSManager.HScore.ToString();
            }
        }
        
    }
    void FixedUpdate()
    {
        LifeText.text = "Life: " + Life; 
        isstandby = PlayerPrefs.GetInt("isStandBy");
        SpeedDown();
        SpeedUp();

        if (VSManager.Battling)
        {
            BattleScore.SetActive(true);
            if (VSManager.Host)
            {
                Debug.Log("Updated");
                BattleScoreText.text = VSManager.GScore.ToString();
            }
            else if (VSManager.Guest)
            {
                Debug.Log("Updated");
                BattleScoreText.text = VSManager.HScore.ToString();
            }
        }
    }


    void ballStart()
    { 
            
        if (Isstop())
        {
            ball.bodyType = RigidbodyType2D.Dynamic;

            ballCollider2D.enabled = true;
            transform.SetParent(null);
            ball.velocity = new Vector2(speedX, speedY);
         
        }
        

    }
    bool Isstop()
    {
        return ball.velocity == Vector2.zero;
    }
    void Update () {
        Score = score;
        if (Input.GetKeyDown(KeyCode.Space) && isstandby ==1)
        {
            ballStart();
        }
        
        PlayerPrefs.SetInt("OOO", score);
    }
    /*void lockSpeed()
    {
        Vector2 lockSpeed = new Vector2(resetspeedX(), resetspeedY());
        ball.velocity = lockSpeed;
    }*/
    void OnCollisionEnter2D(Collision2D other)
    {
        //lockSpeed(); 
        if (other.gameObject.CompareTag("Brick+1"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            SelfscoreText.text =  score.ToString();
        }
        if (other.gameObject.CompareTag("Brick"))
        {
            other.gameObject.SetActive(false);
            score += 10;
            SelfscoreText.text = score.ToString();
        }
        if (other.gameObject.CompareTag("Brick2"))
        {
            other.gameObject.SetActive(false);
            score += 20;
            SelfscoreText.text = score.ToString();
        }
        if (other.gameObject.CompareTag("Brick3"))
        {
            other.gameObject.SetActive(false);
            score += 30;
            SelfscoreText.text = score.ToString();
        }
        if (other.gameObject.CompareTag("Brick4"))
        {
            other.gameObject.SetActive(false);
            score += 40;
            SelfscoreText.text = score.ToString();
        }
        if (other.gameObject.CompareTag("Brick5"))
        {
            other.gameObject.SetActive(false);
            score += 50;
            SelfscoreText.text = score.ToString(); 
        }
        if (other.gameObject.CompareTag("Brick6"))
        {
            other.gameObject.SetActive(false);
            score += 60;
            SelfscoreText.text = score.ToString();
        }
        if (other.gameObject.CompareTag("EffectBrick"))
        {
            score += 10;
            SelfscoreText.text = score.ToString();
        }
        if (other.gameObject.CompareTag("Brick011"))
        {
            Destroy(other.gameObject);
            score += 20;
            SelfscoreText.text = score.ToString();
        }
        if (other.gameObject.CompareTag("Brick012"))
        {
            Destroy(other.gameObject);
            score += 100;
            SelfscoreText.text = score.ToString();

        }
        if (other.gameObject.CompareTag("Brick013"))
        {
            Destroy(other.gameObject);
            score += 30;
            SelfscoreText.text = score.ToString();

        }
        if (other.gameObject.CompareTag("Brick014"))
        {
            Destroy(other.gameObject);
            score += 60;
            SelfscoreText.text = score.ToString();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("In");
            ball.velocity = Vector3.zero;
            ball.bodyType = RigidbodyType2D.Kinematic;
            TheBall.transform.parent = player.transform;
            TheBall.transform.localPosition = new Vector3(-0.08056901f, 0.85f,2.54f);
        }
        else if (other.gameObject.CompareTag("LazerBrick"))
        {
            score += 1;
            SelfscoreText.text = score.ToString();

        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LazerBrick"))
        {
            score += 1;
            SelfscoreText.text = score.ToString();

        }
        if (other.gameObject.CompareTag("LazerBrick10"))
        {
            score += 10;
            SelfscoreText.text = score.ToString();

        }
    }



    float resetspeedX()
    {
        float currentspeedX = ball.velocity.x;
        if (currentspeedX < 0)
        {
            return -speedX;
        }
        else
        {
            return speedX;
        }

    }
    float resetspeedY()
    {
        float currentspeedY = ball.velocity.y;
        if (currentspeedY < 0)
        {
            return -speedY;
        }
        else
        {
            return speedY;
        }

    }
    void SpeedUp()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ball.velocity = new Vector2(ball.velocity.x * 1.009f, ball.velocity.y * 1.009f);
        }

    }
    void SpeedDown()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ball.velocity = new Vector2(ball.velocity.x * 0.95f, ball.velocity.y * 0.95f);
        }

    }
}
