using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_enemy : MonoBehaviour {

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {

            Player player = col.gameObject.GetComponent<Player>();
            player.hurt(1);

            Destroy(gameObject);
        }

    }
}
