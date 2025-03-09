using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_test : MonoBehaviour
{
    public float speed = 5f; //이동 속도
    public float jumppower = 10f; //점프
    public bool checkmove = false; //전진상태인지 체크

    float delay_time = 0f; //랜덤 점프 딜레이 시간
    float stay_tiem = 0f; //충돌 상태 딜레이 시간

    public bool Collision_Hero = false; //Hero Tag와 충돌상태인지 체크
    public bool Collision_Enemy = false; //Enemy Tag와 충돌상태인지 체크

    Vector3 pos;
    private Rigidbody2D rigid;

    int randomfuction; //랜덤점프 딜레이 계산
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pos = this.transform.position;
    }

    // Update is called once per frames
    void Update()
    {
        if (checkmove == true) Move();

        //충돌시 랜덤 점프 구현
        if(Collision_Enemy == true)
        {
            delay_time += Time.deltaTime;
            if (delay_time > 1.0f)
            {
                Randomjump();
                Collision_Enemy = false;
                delay_time = 0f;
            }
        }
        else if(Collision_Hero == true)
        {
            delay_time += Time.deltaTime;
            if (delay_time > 1.0f)
            {
                Randomjump();
                Collision_Hero = false;
                delay_time = 0f;
            }
        }
        else if(Collision_Enemy == true && Collision_Hero == true)
        {
            delay_time += Time.deltaTime;
            if (delay_time > 1.0f)
            {
                Randomjump();
                Collision_Enemy = false;
                Collision_Hero = false;
                delay_time = 0f;
            }
        }
    }
    //전진
    void Move()
    {
        Vector2 movezombie = Vector2.zero;
        movezombie = Vector2.left;
        rigid.velocity = movezombie * speed;
    }
    //후진
    void Move_right()
    {
        Vector2 movezombie = Vector2.zero;
        movezombie = Vector2.right;
        rigid.velocity = movezombie * speed;
    }
    //점프
    void Jump()
    {
        Vector2 jumpzombie = Vector2.zero;
        jumpzombie = Vector2.up;
        Move();
        rigid.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
    }
    //뒤로점프
    void Jump2()
    {
        Vector2 jumpzombie = Vector2.zero;
        jumpzombie = Vector2.up;
        Move_right();
        rigid.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
    }
    //랜덤점프(앞으로점프, 뒤로점프, 무시)
    private void RandomF()
    {
        randomfuction = Random.Range(1, 4);
        delay_time += Time.deltaTime;
        if (delay_time > 1.5)
        {
            switch (randomfuction)
            {
                case 1:
                    Jump();
                    break;
                case 2:
                    Jump2();
                    break;
                case 3:
                    break;
            }
            delay_time = 0f;
        }
    }
    //랜덤점프 (앞으로점프, 전진)
    private void Randomjump()
    {
        randomfuction = Random.Range(1, 3);
        delay_time += Time.deltaTime;
        if (delay_time > 0.5f)
        {
            switch (randomfuction)
            {
                case 1:
                    Jump();
                    break;
                case 2:
                    break;
             
            }
            delay_time = 0f;
        }
    }
    //충돌이벤트(Tag기준)
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            checkmove = false;
            Collision_Enemy = true;
        }
        else if (other.gameObject.tag == "Hero")
        {
            checkmove = false;
            Collision_Hero = true;
        }
        else if(other.gameObject.tag == "Pannel")
        {
            checkmove = true;
        }
    }
    //충돌이 끝났을때 전진하지않고있다면 전진처리
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            stay_tiem += Time.deltaTime;
            if (stay_tiem > 0.2f)
            {
                checkmove = true;
                stay_tiem = 0;
            }
        }
    }
    //좀비끼리 지속 충돌시 점프 처리
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            stay_tiem += Time.deltaTime;
            if (stay_tiem > 1f)
            {
                Jump();
                checkmove = false;
                stay_tiem = 0;
            }
        }
    }
}
