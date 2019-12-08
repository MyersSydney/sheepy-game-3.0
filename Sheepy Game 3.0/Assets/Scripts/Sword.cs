using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PurePower;


public class Sword : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision);
        if (collision.CompareTag("wolf"))
        {
            if (collision.gameObject.GetComponent<Wolf>().hasSheep)
            {
                PurePower.instance.GetComponent<Bin>().AddSheep(1);
            }
            Destroy(collision.gameObject);
            print("you killed me... how dare you");

        }

    }
}
