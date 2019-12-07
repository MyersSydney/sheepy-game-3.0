using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public Transform[] spawners;
    public GameObject[] wolves;
    int randomSpawnPoint;
    int randomWolf;
    public static bool spawnAllowed;
    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAWolf", 0f,1f);
        
    }
    void SpawnAWolf()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawners.Length);
            randomWolf = Random.Range(0, wolves.Length);

           GameObject tmp = Instantiate(wolves[randomWolf], spawners[randomSpawnPoint].position, Quaternion.identity);

           
            tmp.GetComponent<Wolf>().home = spawners[randomSpawnPoint];
        }  
    }
}
