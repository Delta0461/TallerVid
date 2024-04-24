using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_enemy : MonoBehaviour {

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {

            Player player = col.GetComponent<Player>();
            player.hurt(1);

            Destroy(col.gameObject);
        }

    }
}
