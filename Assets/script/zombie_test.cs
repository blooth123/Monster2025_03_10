using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_test : MonoBehaviour
{
    public float speed = 5f; //�̵� �ӵ�
    public float jumppower = 10f; //����
    public bool checkmove = false; //������������ üũ

    float delay_time = 0f; //���� ���� ������ �ð�
    float stay_tiem = 0f; //�浹 ���� ������ �ð�

    public bool Collision_Hero = false; //Hero Tag�� �浹�������� üũ
    public bool Collision_Enemy = false; //Enemy Tag�� �浹�������� üũ

    Vector3 pos;
    private Rigidbody2D rigid;

    int randomfuction; //�������� ������ ���
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

        //�浹�� ���� ���� ����
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
    //����
    void Move()
    {
        Vector2 movezombie = Vector2.zero;
        movezombie = Vector2.left;
        rigid.velocity = movezombie * speed;
    }
    //����
    void Move_right()
    {
        Vector2 movezombie = Vector2.zero;
        movezombie = Vector2.right;
        rigid.velocity = movezombie * speed;
    }
    //����
    void Jump()
    {
        Vector2 jumpzombie = Vector2.zero;
        jumpzombie = Vector2.up;
        Move();
        rigid.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
    }
    //�ڷ�����
    void Jump2()
    {
        Vector2 jumpzombie = Vector2.zero;
        jumpzombie = Vector2.up;
        Move_right();
        rigid.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
    }
    //��������(����������, �ڷ�����, ����)
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
    //�������� (����������, ����)
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
    //�浹�̺�Ʈ(Tag����)
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
    //�浹�� �������� ���������ʰ��ִٸ� ����ó��
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
    //���񳢸� ���� �浹�� ���� ó��
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
