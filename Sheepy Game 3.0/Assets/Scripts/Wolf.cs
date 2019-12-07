using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PurePower;

public class Wolf : MonoBehaviour
{
    [SerializeField]
    public Transform home;

    [SerializeField]
    GameObject bin;

    [SerializeField]
    GameObject sheepFood;

  

    public float moveSpeed = 25;

    public Rigidbody2D rb;
    public Animator animator;

    public SpriteRenderer sr;

    public bool turnAround = false;
    public bool hasSheep = false;

    float timer = 0;
   
    private void Start()
    {
        bin = PurePower.instance.gameObject;
        
    }

    Vector2 movement;
    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (!turnAround)
        {
            if (bin.GetComponent<Bin>().numberrysOfSheep == 0)
            {
                turnAround = true;
            }
            
            transform.position = Vector2.MoveTowards(transform.position, bin.transform.position, moveSpeed * Time.deltaTime);
        }
            else
            {
                if (!hasSheep && timer <= 0)
                {
                    timer = 3;
                    hasSheep = true;
                    bin.GetComponent<Bin>().destroySheep();

                }
         

                transform.position = Vector2.MoveTowards(transform.position, home.transform.position, moveSpeed * Time.deltaTime);
            }
        
    }
    private void Update()
    {
        timer = timer - Time.deltaTime;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wolf")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("home") && turnAround)
        {
            Destroy(gameObject);
            print("i died");
        }

    }

}
  

