using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class fireball : MonoBehaviour {

    public float speed;
    public static int kill=0;

    public GameObject canvasPrefab;
    Vector2 dest = Vector2.zero;

    void Start()
    {
        dest = transform.position;
    }

	void Update () {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) )
            {
                dest = (Vector2)transform.position + Vector2.up*50000;
                this.gameObject.transform.position += new Vector3(0f, speed, 0f);
            }
            if (Input.GetKey(KeyCode.RightArrow) )
            {
                dest = (Vector2)transform.position + Vector2.right*50000;
                this.gameObject.transform.position += new Vector3(speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                dest = (Vector2)transform.position - Vector2.up*50000;
                this.gameObject.transform.position -= new Vector3(0f, speed, 0f);
            }
            if (Input.GetKey(KeyCode.LeftArrow) )
            {
                dest = (Vector2)transform.position - Vector2.right*50000;
                this.gameObject.transform.position -= new Vector3(speed, 0f, 0f);
            }
        }
    }



    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "blinky")
        {
            co.gameObject.SetActive(false);
            kill++;
            Destroy(gameObject);
        }
        else if (co.name == "purple")
        {
            co.gameObject.SetActive(false);
            kill++;
            Destroy(gameObject);
        }
        else if (co.name == "blue")
        {
            co.gameObject.SetActive(false);
            kill++;
            Destroy(gameObject);
        }
        else if (co.name == "green")
        {
            co.gameObject.SetActive(false);
            kill ++;
            Destroy(gameObject);
        }
    }

}