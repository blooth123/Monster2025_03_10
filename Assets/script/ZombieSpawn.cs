using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public Zombie zombiePrefab; // ���� ������
    public Transform[] spawnPoints; // ���� ��ȯ ��ġ
    private List<Zombie> zombies = new List<Zombie>(); // ������ ���� ��� ����Ʈ
    private float Create_Zombie_Time = 0f; //���� ���� �ð�
    public static int list_count = 0; // List count

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Create_Zombie_Time += Time.deltaTime;
        list_count = zombies.Count;
        if (Create_Zombie_Time > 1)
        {
            if (list_count < 31)
            {
                CreateZombie();
            }
            Create_Zombie_Time = 0;
        }
    }
    private void spawnZombie()
    {
        CreateZombie();
    }
    private void CreateZombie()
    {
        //������ ��ġ �������� ����
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        //���� ����
        Zombie zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);

        //������ ���� ����Ʈ�� �߰�
        zombies.Add(zombie);
        
    }
}
