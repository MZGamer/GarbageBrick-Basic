using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
    
    public float speedX;
    Rigidbody2D player001;
	void Start () {
        player001 = GetComponent<Rigidbody2D>();
        speedX = ItemID.ItemObject[Gate.NowAccount.CatcherSet].SpeedX;
	}
	
	
	void Update () {
        if(Dead.Fail!=true)
            move();
	}

    float LeftOrRight()
    {
        return Input.GetAxis("Horizontal");
    }
    void move()
    {
        player001.velocity = LeftOrRight() * new Vector2 (speedX, 0);

    }
}
