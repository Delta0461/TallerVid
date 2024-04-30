using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobility_Debuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Player player = collision.GetComponent<Player>();
            player.Debuff("mobility");
        }
        Destroy(gameObject);
    }
}
