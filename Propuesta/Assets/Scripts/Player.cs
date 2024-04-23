using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float vel = 0;
    void Start() {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void move() {
        float imputX = Input.GetAxis("Horizontal");


        rb.AddForce(new Vector2(20 * imputX, 0));

        Vector2 rbVel = rb.velocity;
        if (rb.velocity.x > vel) {

            rbVel.x = vel;

        }
        if (rb.velocity.x < -vel) {

            rbVel.x = -vel;

        }

        if (imputX == 0) {
            rbVel.x = 0;
        }
        rb.velocity = rbVel;
    }
}
