﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5F;

    public Rigidbody2D rb;
    public Animator animator;

    public SpriteRenderer sr;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        print(movement.sqrMagnitude);
        animator.SetFloat("speed", movement.sqrMagnitude);

        if (movement.x < 0)
        {
            sr.flipX = true;
}
        else
        {
            sr.flipX = false;
        }
        Debug.Log(movement);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}