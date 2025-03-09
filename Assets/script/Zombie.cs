using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject ob;
    public float damage = 20f; // 공격력
    public float timeBetAttack = 0.5f; // 공격 간격
    public float speed = 10f; // 이동 속도
    public float jumppower = 700f; //점프


    float jumpTime = 0f;
    float griTime = 0f;
    float zombiejump = 0f;
    bool updown = true;

    private Rigidbody2D rigid;
    private float Create_Zombie_Time = 0f;
    public bool checkmove = true;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (checkmove == true)
        {
            //Move();
            Jump();
        }
        /*
        else
        {
            zombiejump += Time.deltaTime;
            if (zombiejump > 1f)
            {
                Jump();
                zombiejump = 0f;
            }
        }
        */
    }
    void Move()
    {
        Vector2 movezombie = Vector2.zero;
        movezombie = Vector2.left;
        rigid.velocity = movezombie * speed;
    }
    void Stop()
    {
        Vector2 movezombie = Vector2.zero;
    }
    void Jump()
    {
        Vector2 jumpzombie = Vector2.zero;
        if (updown)
        {
            jumpTime += Time.deltaTime;
        }
        else
            griTime += Time.deltaTime;
        if (updown == true && jumpTime < 0.5f)
        {
            rigid.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
            griTime = 0f;
        }
        else
            updown = false;
        if (updown == false && griTime < 0.5f)
        {
            rigid.AddForce(Vector2.down * jumppower, ForceMode2D.Impulse);
            //rigid.AddForce(new Vector2(0, jumppower_down));
            jumpTime = 0f;
        }
        else
            updown = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            Debug.Log("Stop and Attack");
            checkmove = false;
            Debug.Log(checkmove);
        }
    }
}
