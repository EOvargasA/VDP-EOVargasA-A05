using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadDino : MonoBehaviour {

    public float maxVel = 5f;
    public float yJumpForce = 300f;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 jumpforce;
    private bool isJumping = false;
    private bool isWalking = false;
    private bool moveRigth;

	// Use this for initialization
	void Start () {
        Flip();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpforce = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float v = Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rb.velocity.y);

        v *= maxVel;

        vel.x = v;

        rb.velocity = vel;

        if (v != 0) {
            anim.SetBool("isWalking", true);
        } else {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetAxis("Jump") > 0.01f) {
            if (!isJumping) {
                if (rb.velocity.y == 0f)
                {
                    anim.SetBool("isJumping", true);
                    isJumping = true;
                    jumpforce.x = 0f;
                    jumpforce.y = yJumpForce;
                    rb.AddForce(jumpforce);
                }
            }
        } else {
            anim.SetBool("isJumping", false);
            isJumping = false;
        }
        

        if (moveRigth && v < 0) {
            moveRigth = false;
            Flip();
        } else if (!moveRigth && v > 0) {
            moveRigth = true;
            Flip();
        }

    }

    private void Flip() {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}
