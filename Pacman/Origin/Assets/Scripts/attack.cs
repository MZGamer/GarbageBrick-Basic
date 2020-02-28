using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {

    public GameObject fireball;//子彈
    public float shoot_Pos;//為了讓子彈在腳色的前面一點出現
    static public int fireball_amount = 2,useball=0;

	void Start () {
		
	}
	
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space) && fireball_amount > 0)
        {
            Instantiate(fireball, (this.gameObject.transform.position + new Vector3(shoot_Pos, 0f, 0f)), this.gameObject.transform.rotation);
            fireball_amount--;
            useball++;
        }
    }
}
