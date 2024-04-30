using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class Player : MonoBehaviour {
    Rigidbody2D rb;
    public float vel = 1; //velocidad básica del jugador, tanto en eje x como en y
    bool Jump_check = true; //true es que puede saltar
    public int hp = 5;
    bool ArrowDown = false;
    bool Invulnerability = false;
    bool agacharseActivo = false;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        move();
    }
    public void Buff(string buff) {
        switch (buff) {
            case "inve":
                Invulnerability = true;
                StopCoroutine(mobility_D());
                vel = 1;
                StartCoroutine(Inven());
                break;
            case "heal":
                StopCoroutine(mobility_D());
                vel = 1;
                hurt(-1);
                break;
        }
    }
    public void Debuff(string debuff) {
        switch (debuff) {
            case "mobility":
                StartCoroutine(mobility_D());
                break;

        }
    }
    private IEnumerator mobility_D() {
        vel = 0.6f;
        yield return new WaitForSeconds(4);
        vel = 1;
    }
    private IEnumerator Inven() {
        Invulnerability = true;
        yield return new WaitForSeconds(8f);
        Invulnerability = false;
    }
    void move() {
        float vely = 0;
        float inputX = Input.GetAxis("Horizontal");

        Vector2 rbVel = rb.velocity;
        if (rb.velocity.x > vel) {
            rbVel.x = vel;
        }
        if (rb.velocity.x < -vel) {
            rbVel.x = -vel;
        }

        if (inputX == 0) {
            rbVel.x = 0;
        }
        rb.velocity = rbVel;
        if (Input.GetKeyDown(KeyCode.Space) && Jump_check) {
            Jump_check = false;
            vely = 700 * vel;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) ) {
            ArrowDown = true;
            if(!agacharseActivo){
                agacharseActivo = true;
                if(agacharseActivo) StartCoroutine(Agachado());
            }
            
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            ArrowDown = false;
        }
        rb.AddForce(new Vector2(20 * inputX, vely));
    }
    public void hurt(int damage) {
        if(!Invulnerability || damage<0) hp -= damage;//Se puede curar mientras es invulnerable, pero no hacerse daño
        if (hp >= 5) hp=5;//Limite de vida max.
        Debug.Log(hp);
        if (hp <= 0) {
            hp = 0;
            Destroy(gameObject);
            GameObject gcObj = GameObject.FindGameObjectWithTag("GameController");//Termina la partida
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Suelo" || col.gameObject.tag == "Plataform") {
            Jump_check = true;
        }//Limite de salto
        if (ArrowDown && col.gameObject.tag == "Plataform") {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>(), true);
        }//Bajar de plataforma mientras cae
        if (col.gameObject.tag == "break") {
            Plataform_Break por_romper = col.gameObject.GetComponent<Plataform_Break>();
            por_romper.romper();
        }//Activa el conteo para romper los objetos quebradizos

    
    }
    private void OnCollisionStay2D(Collision2D col) {
        if (ArrowDown && col.gameObject.tag == "Plataform") {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>(), true);
        }//Bajar de plataforma mientras esta reposado sobre la plataforma
    }
    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Plataform") {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>(), false);
        }//Poder volver a subir a la plataforma
    }
    IEnumerator Agachado() {
        Vector2 agachado = new Vector2(1.8f, 1f);
        transform.localScale = new Vector3(agachado.x, agachado.y, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5556f, transform.position.z);
        yield return new WaitForSeconds(1.4f);
        transform.localScale = new Vector3(1,2.1f,transform.localScale.z);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5556f, transform.position.z);
        agacharseActivo = false;

    }//Recupera su tamaño inicial despues del tiempo
}
