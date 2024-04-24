using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float vel = 15; //velocidad básica del jugador, tanto en eje x como en y
    public bool Jump_check = true; //true es que puede saltar
    public int hp = 5;
    void Start() {
        rb= GetComponent<Rigidbody2D>();
    }
    void Update() {
        move();
        
    }
    void move() {
        float vely = 0;
        float imputX = Input.GetAxis("Horizontal");

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

        if (Input.GetKeyDown(KeyCode.Space) && Jump_check) {
            //Jump_check = false;
            vely = 700;
        }

        rb.AddForce(new Vector2(20 * imputX, vely));
    }
    public void hurt(int damage) {
        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0) {
            hp = 0;
            Destroy(gameObject);
            GameObject gcObj = GameObject.FindGameObjectWithTag("GameController");//busca una etiqueta (tag)
        }
    }
    /*private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Suelo") {
            Jump_check = true;
        }
    }*/
}
