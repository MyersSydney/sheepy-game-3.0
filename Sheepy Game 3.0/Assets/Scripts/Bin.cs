﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    int sheepToSpawn = 0;
    public int numberrysOfSheep = 0;

    float x;
    float y;

    [SerializeField]
    GameObject spawnerPos;

    [SerializeField]
    GameObject sheepos;

    int maxMore = 4;
    int maxCap = 20;

    float timer = 0;


    List <GameObject> listOfSheepos;

    void Start()
    {
        listOfSheepos = new List<GameObject>();
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
            GameObject tmp = Instantiate(sheepos, new Vector2(Random.Range(spawnerPos.transform.position.x, spawnerPos.transform.position.x + maxMore), Random.Range(spawnerPos.transform.position.y, spawnerPos.transform.position.y - maxMore)), Quaternion.identity);
            //make sheep
           listOfSheepos.Add(tmp);

            numberrysOfSheep++;
            sheepToSpawn--;

            

        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("wolf")){
            other.GetComponent<Wolf>().turnAround = true;
           

        }
       
    }
    public void destroySheep()
    {
        if (numberrysOfSheep > 0)
        {
            print("yum");
            listOfSheepos.RemoveAt(0);
        }
        else
        {
            //no wolves
        }
    }

}
