using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    GameObject target;

    int maxMore = 4;
    int maxCap = 20;

    float timer = 0;

    public bool nextRound = false;

    [SerializeField]
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
        if(nextRound == true)
        {
            sheepToSpawn = (int)((.25 * numberrysOfSheep) + 2);
            nextRound = false;
        }
        lose();
       
    }
    public void AddSheep(int n = -1)
    {
        if (n <= 0)
        {
            for (int i = 0; i < Random.Range(1, sheepToSpawn); i++)
            {
                if (numberrysOfSheep == maxCap)
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
        
        else
        {
            GameObject tmp = Instantiate(sheepos, new Vector2(Random.Range(spawnerPos.transform.position.x, spawnerPos.transform.position.x + maxMore), Random.Range(spawnerPos.transform.position.y, spawnerPos.transform.position.y - maxMore)), Quaternion.identity);
            //make sheep
            listOfSheepos.Add(tmp);
            numberrysOfSheep++;
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
            GameObject tmp2 = listOfSheepos[0];
            listOfSheepos.RemoveAt(0);
            numberrysOfSheep--;
            Destroy(tmp2);
        }
        
       
    }
   void lose()
    {
        if(numberrysOfSheep <= 0)
        {
            FindObjectOfType<GameManager>().GameOver();

        }
    }

}
