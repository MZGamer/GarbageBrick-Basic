using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManMoveTest : MonoBehaviour {
    public Vector2 move;
    public Vector3 rotate;
    public float speed;
	// Use this for initialization
	void Start () {
        move = (Vector2)transform.position;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
    }

    public void Move()
    {
        move = (Vector2)transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move.y += speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move.y -= speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move.x -= speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move.x += speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        transform.position = move;
    }
    
    public void rotating()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }


}
