using System.Collections;
using System.Collections.Generic; //Я�������
using UnityEngine;

enum SpawnState
{
    NotStart,Spawning,End
}


public class ZombieManger : MonoBehaviour
{
    public static ZombieManger Instance { get; private set; }
    private SpawnState spawnState = SpawnState.NotStart;
    public Transform[] spawnPointList;
    public GameObject zombiePrefab;
    private void Awake()
    {
        Instance = this; 
    }
    private void Start()
    {
        StartSpawn();
    }
    public void StartSpawn()
    {
        spawnState = SpawnState.Spawning;
        StartCoroutine(SpawnZombie());
    }

    //Я������
    IEnumerator SpawnZombie()
    {
        //��һ��
        for (int i=0;i<5;i++)
        {
            SpawnARandomZombie();
            //��3s
            yield return new WaitForSeconds(3);
        }

        yield return new WaitForSeconds(4);

        //�ڶ���
        for (int i = 0; i < 7; i++)
        {
            SpawnARandomZombie();
            //��3s
            yield return new WaitForSeconds(2);
        }

    }

    private void SpawnARandomZombie()
    {
        int index = Random.Range(0, spawnPointList.Length);
        GameObject.Instantiate(zombiePrefab, spawnPointList[index].position,Quaternion.identity);
    }
}
