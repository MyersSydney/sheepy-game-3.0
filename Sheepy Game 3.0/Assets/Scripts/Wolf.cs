﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    [SerializeField]
    GameObject home;

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
    Bin b;
    private void Start()
    {
        b = PurePower.instance.gameObject.GetComponent<Bin>();
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
                b.destroySheep();
               
            }

            transform.position = Vector2.MoveTowards(transform.position, home.transform.position, moveSpeed * Time.deltaTime);

        }
        
    }
}
  
