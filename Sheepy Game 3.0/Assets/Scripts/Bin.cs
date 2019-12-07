using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    int sheepToSpawn = 0;
    int numberrysOfSheep = 0;

    float x;
    float y;

    [SerializeField]
    GameObject spawnerPos;

    [SerializeField]
    GameObject sheepos;

    int maxMore = 4;
    int maxCap = 20;

    float timer = 0;


    void Start()
    {
        sheepToSpawn = 2;
        x = spawnerPos.transform.position.x;
        y = spawnerPos.transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sheepToSpawn > 0)
        {
            AddSheep();
        }
        if(Input.GetKeyDown(KeyCode.Space) && numberrysOfSheep <= maxCap)
        {
            sheepToSpawn = (int)((.25 * numberrysOfSheep) + 2);
        }
       
    }
    void AddSheep()
    {
        for(int i = 0; i < Random.Range(1, sheepToSpawn); i++){
            if(numberrysOfSheep == maxCap)
            {
                sheepToSpawn = 0;
                break;
            }
            //make sheep
            Instantiate(sheepos, new Vector2(Random.Range(spawnerPos.transform.position.x, spawnerPos.transform.position.x + maxMore), Random.Range(spawnerPos.transform.position.y, spawnerPos.transform.position.y - maxMore)), Quaternion.identity);

            numberrysOfSheep++;
            sheepToSpawn--;


        }
        print(numberrysOfSheep);
    }
}
