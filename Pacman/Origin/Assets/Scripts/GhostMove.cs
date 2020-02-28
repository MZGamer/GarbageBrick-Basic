using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;
    public static float speed = 0.2f;
    public static bool gg = false; 
    


    void FixedUpdate()
    {
        // 尚未到達航點 然後靠近
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // 到達Waypoint，選擇下一個
        else cur = (cur + 1) % waypoints.Length;

        // 動畫

        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    public GameObject canvasPrefab;


    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            Destroy(co.gameObject);
            gg = true;
        }
    }
}
