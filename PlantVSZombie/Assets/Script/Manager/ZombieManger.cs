using System.Collections;
using System.Collections.Generic; //携程需包含
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

    private List<Zombie> zombieList = new List<Zombie>();
    private void Awake()
    {
        Instance = this; 
    }
    private void Start()
    {
        //StartSpawn();
    }
    public void StartSpawn()
    {
        spawnState = SpawnState.Spawning;
        StartCoroutine(SpawnZombie());
    }

    public void Pause()
    {
        spawnState = SpawnState.End;
        foreach (var zombie in zombieList)
        {
            zombie.TransitionToPause();
        }
    }

    //携程生成
    IEnumerator SpawnZombie()
    {
        //第一波
        for (int i=0;i<5;i++)
        {
            SpawnARandomZombie();
            //等3s
            yield return new WaitForSeconds(3);
        }

        yield return new WaitForSeconds(4);

        AudioManager.instance.PlayClip(Config.lastwave);
        //第二波
        for (int i = 0; i < 7; i++)
        {
            SpawnARandomZombie();
            //等3s
            yield return new WaitForSeconds(2);
        }
        spawnState = SpawnState.End;
    }

    private void Update()
    {
        if (spawnState == SpawnState.End && zombieList.Count == 0)
        {
            GameManager.instance.GameEndSuccess();
        }
    }

    private void SpawnARandomZombie()
    {
        if (spawnState == SpawnState.Spawning)
        {
            int index = Random.Range(0, spawnPointList.Length);
            GameObject go = GameObject.Instantiate(zombiePrefab, spawnPointList[index].position, Quaternion.identity);
            zombieList.Add(go.GetComponent<Zombie>());
            go.GetComponent<SpriteRenderer>().sortingOrder = spawnPointList[index].GetComponent<SpriteRenderer>().sortingOrder;
        }
    }

    public void RemoveZombie(Zombie zombie)
    {
        zombieList.Remove(zombie);
    }
}
