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

  

    public float moveSpeed = 1F;

    public Rigidbody2D rb;
    public Animator animator;

    public SpriteRenderer sr;

    public bool turnAround = false;
    public bool hasSheep = false;
   
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
            transform.position = Vector2.MoveTowards(transform.position, bin.transform.position, moveSpeed * Time.deltaTime);
        }
            if (turnAround)
            {
                if (!hasSheep)
                {
                    hasSheep = true;
                    bin.GetComponent<Bin>().destroySheep();

                }

                transform.position = Vector2.MoveTowards(transform.position, home.transform.position, moveSpeed * Time.deltaTime);
            }
        
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "wolf")
            {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (transform.position == home.transform.position && turnAround)
        {
            Destroy(collision.gameObject);
            print("i died");
        }

    }

}
  

