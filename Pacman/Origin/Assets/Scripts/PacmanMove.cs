using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Text
public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;

    public GameObject canvasPrefab;

    Vector2 dest = Vector2.zero;


    void Start()
    {
        dest = transform.position;
    }


    void Update()
    {
        OnAnimatorMove();
        // 靠近目的地
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        // 動畫參數
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }


    bool valid(Vector2 dir)
    {
        // 從'Pac-Man旁邊'投射線到'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
    private void OnAnimatorMove()
    {
        // 檢查輸入是否移動
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            else if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            else if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            else if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }
    }
}