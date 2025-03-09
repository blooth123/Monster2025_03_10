using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public Zombie zombiePrefab; // 좀비 프리펩
    public Transform[] spawnPoints; // 좀비 소환 위치
    private List<Zombie> zombies = new List<Zombie>(); // 생성된 좀비를 담는 리스트
    private float Create_Zombie_Time = 0f; //좀비 생성 시간
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
        //생성할 위치 랜덤으로 결정
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        //좀비 생성
        Zombie zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);

        //생성된 좀비 리스트에 추가
        zombies.Add(zombie);
        
    }
}
