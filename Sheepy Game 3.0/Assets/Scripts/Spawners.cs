using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PurePower;



public class Spawners : MonoBehaviour
{
    [SerializeField]
    GameObject bin;

    public Transform[] spawners;
    public GameObject[] wolves;
    int randomSpawnPoint;
    int randomWolf;
    public bool spawnAllowed;
    int wolvesToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        bin = PurePower.instance.gameObject;
        spawnAllowed = true;
        updateTheNumWolves();
    }
    private void Update()
    {
        if (bin.GetComponent<Bin>().numberrysOfSheep <= 0)
        {
            spawnAllowed = false;
        }
        else
        {
            spawnAllowed = true;
        }
    }
    public void SpawnAWolf()
    {
        if (spawnAllowed)
        {
            
            for (int i = 0; i < wolvesToSpawn; i++)
            {
                randomSpawnPoint = Random.Range(0, spawners.Length);
                randomWolf = Random.Range(0, wolves.Length);
                GameObject tmp = Instantiate(wolves[randomWolf], spawners[randomSpawnPoint].position, Quaternion.identity);


                tmp.GetComponent<Wolf>().home = spawners[randomSpawnPoint];
            }
            
        }  
        
    }
    public void updateTheNumWolves()
    {
        wolvesToSpawn = GameManager.instance.wave * GameManager.instance.wave + 3;
    }
}
