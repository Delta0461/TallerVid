using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patas : MonoBehaviour
{
    public Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Suelo") {
            player.PatasPisando = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Plataform" ) {
            player.PatasPisando = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if( collision.gameObject.tag == "Plataform") {
            player.PatasPisando= true;
        }
    }
}
