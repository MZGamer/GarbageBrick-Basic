using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    public GameObject TheBall,player;
    public SpriteRenderer BallSp, playersp;
    Rigidbody2D ball;
    public float speedX;
    public float speedY;
    public Text scoreText;
    CircleCollider2D ballCollider2D;
    public int score;
    private int isstandby;
   
   


    void Start () {
        if (Gate.Login)
        {
            BallSp.sprite = ItemID.ItemList[Gate.NowAccount.BallSet];
            playersp.sprite = ItemID.ItemList[Gate.NowAccount.CatcherSet];
        }
        ball = GetComponent<Rigidbody2D>();
        
        scoreText.text = "Score: ";
        ballCollider2D = GetComponent<CircleCollider2D>();
        
    }
    void FixedUpdate()
    {
        isstandby = PlayerPrefs.GetInt("isStandBy");
        SpeedDown();
        SpeedUp();
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
            scoreText.text = "Score: " + score;
        }
        if (other.gameObject.CompareTag("Brick"))
        {
            other.gameObject.SetActive(false);
            score += 10;
            scoreText.text = "Score: " + score;
        }
        if (other.gameObject.CompareTag("Brick2"))
        {
            other.gameObject.SetActive(false);
            score += 20;
            scoreText.text = "Score: " + score;
        }
        if (other.gameObject.CompareTag("Brick3"))
        {
            other.gameObject.SetActive(false);
            score += 30;
            scoreText.text = "Score: " + score;
        }
        if (other.gameObject.CompareTag("Brick4"))
        {
            other.gameObject.SetActive(false);
            score += 40;
            scoreText.text = "Score: " + score;
        }
        if (other.gameObject.CompareTag("Brick5"))
        {
            other.gameObject.SetActive(false);
            score += 50;
            scoreText.text = "Score: " + score;
        }
        if (other.gameObject.CompareTag("Brick6"))
        {
            other.gameObject.SetActive(false);
            score += 60;
            scoreText.text = "Score: " + score;
        }
        if (other.gameObject.CompareTag("EffectBrick"))
        {
            score += 10;
            scoreText.text = "Score: " + score;
        }
        if (other.gameObject.CompareTag("Brick011"))
        {
            Destroy(other.gameObject);
            score += 20;
            scoreText.text = "Score: " + score;
        }
        if (other.gameObject.CompareTag("Brick012"))
        {
            Destroy(other.gameObject);
            score += 100;
            scoreText.text = "Score: " + score;

        }
        if (other.gameObject.CompareTag("Brick013"))
        {
            Destroy(other.gameObject);
            score += 30;
            scoreText.text = "Score: " + score;

        }
        if (other.gameObject.CompareTag("Brick014"))
        {
            Destroy(other.gameObject);
            score += 60;
            scoreText.text = "Score: " + score;
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
            scoreText.text = "Score: " + score;

        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LazerBrick"))
        {
            score += 1;
            scoreText.text = "Score: " + score;

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
